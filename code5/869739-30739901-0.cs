    using System;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    namespace ReadAuthenticodeSignatures
    {
        internal static class Program
        {
            internal static void Main(string[] args)
            {
                string fileName = args[0];
                IntPtr hWind = IntPtr.Zero;
                Guid WINTRUST_ACTION_GENERIC_VERIFY_V2 = new Guid("{00AAC56B-CD44-11d0-8CC2-00C04FC295EE}");
                byte[] actionIdBytes = WINTRUST_ACTION_GENERIC_VERIFY_V2.ToByteArray();
                IntPtr pcwszFilePath = Marshal.StringToHGlobalAuto(fileName);
                try
                {
                    WINTRUST_FILE_INFO File = new WINTRUST_FILE_INFO()
                    {
                        cbStruct = Marshal.SizeOf(typeof(WINTRUST_FILE_INFO)),
                        pcwszFilePath = pcwszFilePath,
                        hFile = IntPtr.Zero,
                        pgKnownSubject = IntPtr.Zero,
                    };
                    IntPtr ptrFile = Marshal.AllocHGlobal(File.cbStruct);
                    try
                    {
                        Marshal.StructureToPtr(File, ptrFile, false);
                        WINTRUST_DATA WVTData = new WINTRUST_DATA()
                        {
                            cbStruct = Marshal.SizeOf(typeof(WINTRUST_DATA)),
                            pPolicyCallbackData = IntPtr.Zero,
                            pSIPClientData = IntPtr.Zero,
                            dwUIChoice = WTD_UI_NONE,
                            fdwRevocationChecks = WTD_REVOKE_NONE,
                            dwUnionChoice = WTD_CHOICE_FILE,
                            pFile = ptrFile,
                            dwStateAction = WTD_STATEACTION_IGNORE,
                            hWVTStateData = IntPtr.Zero,
                            pwszURLReference = IntPtr.Zero,
                            dwProvFlags = WTD_REVOCATION_CHECK_NONE,
                            dwUIContext = WTD_UICONTEXT_EXECUTE,
                            pSignatureSettings = IntPtr.Zero,
                        };
                        // N.B. Use of this member is only supported on Windows 8 and Windows Server 2012 (and later)
                        WINTRUST_SIGNATURE_SETTINGS signatureSettings = default(WINTRUST_SIGNATURE_SETTINGS);
                        bool canUseSignatureSettings = Environment.OSVersion.Version > new Version(6, 2, 0, 0);
                        IntPtr pSignatureSettings = IntPtr.Zero;
                        if (canUseSignatureSettings)
                        {
                            // Setup WINTRUST_SIGNATURE_SETTINGS to get the number of signatures in the file
                            signatureSettings = new WINTRUST_SIGNATURE_SETTINGS()
                            {
                                cbStruct = Marshal.SizeOf(typeof(WINTRUST_SIGNATURE_SETTINGS)),
                                dwIndex = 0,
                                dwFlags = WSS_GET_SECONDARY_SIG_COUNT,
                                cSecondarySigs = 0,
                                dwVerifiedSigIndex = 0,
                                pCryptoPolicy = IntPtr.Zero,
                            };
                            pSignatureSettings = Marshal.AllocHGlobal(signatureSettings.cbStruct);
                        }
                        try
                        {
                            if (pSignatureSettings != IntPtr.Zero)
                            {
                                Marshal.StructureToPtr(signatureSettings, pSignatureSettings, false);
                                WVTData.pSignatureSettings = pSignatureSettings;
                            }
                            IntPtr pgActionID = Marshal.AllocHGlobal(actionIdBytes.Length);
                            try
                            {
                                Marshal.Copy(actionIdBytes, 0, pgActionID, actionIdBytes.Length);
                                IntPtr pWVTData = Marshal.AllocHGlobal(WVTData.cbStruct);
                                try
                                {
                                    Marshal.StructureToPtr(WVTData, pWVTData, false);
                                    int hRESULT = WinVerifyTrust(hWind, pgActionID, pWVTData);
                                    if (hRESULT == 0)
                                    {
                                        if (pSignatureSettings != IntPtr.Zero)
                                        {
                                            // Read back the signature settings
                                            signatureSettings = (WINTRUST_SIGNATURE_SETTINGS)Marshal.PtrToStructure(pSignatureSettings, typeof(WINTRUST_SIGNATURE_SETTINGS));
                                        }
                                        int signatureCount = signatureSettings.cSecondarySigs + 1;
                                        Console.WriteLine("File: {0}", fileName);
                                        Console.WriteLine("Authenticode signatures: {0}", signatureCount);
                                        Console.WriteLine();
                                        for (int dwIndex = 0; dwIndex < signatureCount; dwIndex++)
                                        {
                                            if (pSignatureSettings != IntPtr.Zero)
                                            {
                                                signatureSettings.dwIndex = dwIndex;
                                                signatureSettings.dwFlags = WSS_VERIFY_SPECIFIC;
                                                Marshal.StructureToPtr(signatureSettings, pSignatureSettings, false);
                                            }
                                            WVTData.dwStateAction = WTD_STATEACTION_VERIFY;
                                            WVTData.hWVTStateData = IntPtr.Zero;
                                            Marshal.StructureToPtr(WVTData, pWVTData, false);
                                            hRESULT = WinVerifyTrust(hWind, pgActionID, pWVTData);
                                            try
                                            {
                                                if (hRESULT == 0)
                                                {
                                                    WVTData = (WINTRUST_DATA)Marshal.PtrToStructure(pWVTData, typeof(WINTRUST_DATA));
                                                    IntPtr ptrProvData = WTHelperProvDataFromStateData(WVTData.hWVTStateData);
                                                    CRYPT_PROVIDER_DATA provData = (CRYPT_PROVIDER_DATA)Marshal.PtrToStructure(ptrProvData, typeof(CRYPT_PROVIDER_DATA));
                                                    for (int idxSigner = 0; idxSigner < provData.csSigners; idxSigner++)
                                                    {
                                                        IntPtr ptrProvSigner = WTHelperGetProvSignerFromChain(ptrProvData, idxSigner, false, 0);
                                                        CRYPT_PROVIDER_SGNR ProvSigner = (CRYPT_PROVIDER_SGNR)Marshal.PtrToStructure(ptrProvSigner, typeof(CRYPT_PROVIDER_SGNR));
                                                        CMSG_SIGNER_INFO Signer = (CMSG_SIGNER_INFO)Marshal.PtrToStructure(ProvSigner.psSigner, typeof(CMSG_SIGNER_INFO));
                                                        if (Signer.HashAlgorithm.pszObjId != IntPtr.Zero)
                                                        {
                                                            string objId = Marshal.PtrToStringAnsi(Signer.HashAlgorithm.pszObjId);
                                                            if (objId != null)
                                                            {
                                                                Oid hashOid = Oid.FromOidValue(objId, OidGroup.All);
                                                                if (hashOid != null)
                                                                {
                                                                    Console.WriteLine("Hash algorithm of signature {0}: {1}.", dwIndex + 1, hashOid.FriendlyName);
                                                                }
                                                            }
                                                        }
                                                        IntPtr ptrCert = WTHelperGetProvCertFromChain(ptrProvSigner, idxSigner);
                                                        CRYPT_PROVIDER_CERT cert = (CRYPT_PROVIDER_CERT)Marshal.PtrToStructure(ptrCert, typeof(CRYPT_PROVIDER_CERT));
                                                        if (cert.cbStruct > 0)
                                                        {
                                                            X509Certificate2 certificate = new X509Certificate2(cert.pCert);
                                                            Console.WriteLine("Certificate thumbprint of signature {0}: {1}", dwIndex + 1, certificate.Thumbprint);
                                                        }
                                                        if (ProvSigner.sftVerifyAsOf.dwHighDateTime != provData.sftSystemTime.dwHighDateTime &&
                                                            ProvSigner.sftVerifyAsOf.dwLowDateTime != provData.sftSystemTime.dwLowDateTime)
                                                        {
                                                            DateTime timestamp = DateTime.FromFileTimeUtc(((long)ProvSigner.sftVerifyAsOf.dwHighDateTime << 32) | (uint)ProvSigner.sftVerifyAsOf.dwLowDateTime);
                                                            Console.WriteLine("Timestamp of signature {0}: {1}", dwIndex + 1, timestamp);
                                                        }
                                                    }
                                                }
                                            }
                                            finally
                                            {
                                                WVTData.dwStateAction = WTD_STATEACTION_CLOSE;
                                                Marshal.StructureToPtr(WVTData, pWVTData, false);
                                                hRESULT = WinVerifyTrust(hWind, pgActionID, pWVTData);
                                            }
                                            Console.WriteLine();
                                        }
                                    }
                                    else if ((uint)hRESULT == 0x800b0100)
                                    {
                                        Console.WriteLine("{0} has no Authenticode signatures.", fileName);
                                    }
                                }
                                finally
                                {
                                    Marshal.FreeHGlobal(pWVTData);
                                }
                            }
                            finally
                            {
                                Marshal.FreeHGlobal(pgActionID);
                            }
                        }
                        finally
                        {
                            if (pSignatureSettings != IntPtr.Zero)
                            {
                                Marshal.FreeHGlobal(pSignatureSettings);
                            }
                        }
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(ptrFile);
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(pcwszFilePath);
                }
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
            private const int SGNR_TYPE_TIMESTAMP = 0x00000010;
            private const int WTD_UI_NONE = 2;
            private const int WTD_CHOICE_FILE = 1;
            private const int WTD_REVOKE_NONE = 0;
            private const int WTD_REVOKE_WHOLECHAIN = 1;
            private const int WTD_STATEACTION_IGNORE = 0;
            private const int WTD_STATEACTION_VERIFY = 1;
            private const int WTD_STATEACTION_CLOSE = 2;
            private const int WTD_REVOCATION_CHECK_NONE = 16;
            private const int WTD_REVOCATION_CHECK_CHAIN = 64;
            private const int WTD_UICONTEXT_EXECUTE = 0;
            private const int WSS_VERIFY_SPECIFIC = 0x00000001;
            private const int WSS_GET_SECONDARY_SIG_COUNT = 0x00000002;
            [DllImport("wintrust.dll")]
            private static extern int WinVerifyTrust(IntPtr hWind, IntPtr pgActionID, IntPtr pWVTData);
            [DllImport("wintrust.dll")]
            private static extern IntPtr WTHelperProvDataFromStateData(IntPtr hStateData);
            [DllImport("wintrust.dll")]
            private static extern IntPtr WTHelperGetProvSignerFromChain(IntPtr pProvData, int idxSigner, bool fCounterSigner, int idxCounterSigner);
            [DllImport("wintrust.dll")]
            private static extern IntPtr WTHelperGetProvCertFromChain(IntPtr pSgnr, int idxCert);
            [StructLayout(LayoutKind.Sequential)]
            private struct WINTRUST_DATA
            {
                internal int cbStruct;
                internal IntPtr pPolicyCallbackData;
                internal IntPtr pSIPClientData;
                internal int dwUIChoice;
                internal int fdwRevocationChecks;
                internal int dwUnionChoice;
                internal IntPtr pFile;
                internal int dwStateAction;
                internal IntPtr hWVTStateData;
                internal IntPtr pwszURLReference;
                internal int dwProvFlags;
                internal int dwUIContext;
                internal IntPtr pSignatureSettings;
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct WINTRUST_SIGNATURE_SETTINGS
            {
                internal int cbStruct;
                internal int dwIndex;
                internal int dwFlags;
                internal int cSecondarySigs;
                internal int dwVerifiedSigIndex;
                internal IntPtr pCryptoPolicy;
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct WINTRUST_FILE_INFO
            {
                internal int cbStruct;
                internal IntPtr pcwszFilePath;
                internal IntPtr hFile;
                internal IntPtr pgKnownSubject;
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct CRYPT_PROVIDER_DATA
            {
                internal int cbStruct;
                internal IntPtr pWintrustData;
                internal bool fOpenedFile;
                internal IntPtr hWndParent;
                internal IntPtr pgActionID;
                internal IntPtr hProv;
                internal int dwError;
                internal int dwRegSecuritySettings;
                internal int dwRegPolicySettings;
                internal IntPtr psPfns;
                internal int cdwTrustStepErrors;
                internal IntPtr padwTrustStepErrors;
                internal int chStores;
                internal IntPtr pahStores;
                internal int dwEncoding;
                internal IntPtr hMsg;
                internal int csSigners;
                internal IntPtr pasSigners;
                internal int csProvPrivData;
                internal IntPtr pasProvPrivData;
                internal int dwSubjectChoice;
                internal IntPtr pPDSip;
                internal IntPtr pszUsageOID;
                internal bool fRecallWithState;
                internal System.Runtime.InteropServices.ComTypes.FILETIME sftSystemTime;
                internal IntPtr pszCTLSignerUsageOID;
                internal int dwProvFlags;
                internal int dwFinalError;
                internal IntPtr pRequestUsage;
                internal int dwTrustPubSettings;
                internal int dwUIStateFlags;
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct CRYPT_PROVIDER_SGNR
            {
                internal int cbStruct;
                internal System.Runtime.InteropServices.ComTypes.FILETIME sftVerifyAsOf;
                internal int csCertChain;
                internal IntPtr pasCertChain;
                internal int dwSignerType;
                internal IntPtr psSigner;
                internal int dwError;
                internal int csCounterSigners;
                internal IntPtr pasCounterSigners;
                internal IntPtr pChainContext;
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct CRYPT_PROVIDER_CERT
            {
                internal int cbStruct;
                internal IntPtr pCert;
                internal bool fCommercial;
                internal bool fTrustedRoot;
                internal bool fSelfSigned;
                internal bool fTestCert;
                internal int dwRevokedReason;
                internal int dwConfidence;
                internal int dwError;
                internal IntPtr pTrustListContext;
                internal bool fTrustListSignerCert;
                internal IntPtr pCtlContext;
                internal int dwCtlError;
                internal bool fIsCyclic;
                internal IntPtr pChainElement;
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct CRYPT_ALGORITHM_IDENTIFIER
            {
                internal IntPtr pszObjId;
                internal CRYPT_INTEGER_BLOB Parameters;
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct CMSG_SIGNER_INFO
            {
                internal int dwVersion;
                internal CRYPT_INTEGER_BLOB Issuer;
                internal CRYPT_INTEGER_BLOB SerialNumber;
                internal CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm;
                internal CRYPT_ALGORITHM_IDENTIFIER HashEncryptionAlgorithm;
                internal CRYPT_INTEGER_BLOB EncryptedHash;
                internal CRYPT_ATTRIBUTES AuthAttrs;
                internal CRYPT_ATTRIBUTES UnauthAttrs;
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct CRYPT_INTEGER_BLOB
            {
                internal int cbData;
                internal IntPtr pbData;
            }
            [StructLayout(LayoutKind.Sequential)]
            private struct CRYPT_ATTRIBUTES
            {
                internal int cAttr;
                internal IntPtr rgAttr;
            }
        }
    }
