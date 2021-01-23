    using System;
    using System.Runtime.InteropServices;
    
    namespace SilverlightX509Store
    {
        public static class CapiNative
        {
            public const string MY = "MY";
            public const uint PKCS_7_ASN_ENCODING = 0x00010000;
            public const uint X509_ASN_ENCODING = 0x00000001;
            public const uint CERT_FIND_SUBJECT_STR = 0x00080007;
            public const int ACCESS_DENIED = 5;
    
            [DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr CertOpenSystemStore(
                IntPtr hCryptProv,
                string storename);
    
            [DllImport("crypt32.dll", SetLastError = true)]
            public static extern IntPtr CertFindCertificateInStore(
                IntPtr hCertStore,
                uint dwCertEncodingType,
                uint dwFindFlags,
                uint dwFindType,
                [In, MarshalAs(UnmanagedType.LPWStr)]String pszFindString,
                IntPtr pPrevCertCntxt);
        }
    
        public class CapiWrapper
        {
            public IntPtr FindCert(string subject)
            {
                IntPtr storeHandle = CapiNative.CertOpenSystemStore(
                    IntPtr.Zero, 
                    CapiNative.MY);
    
                if (Marshal.GetLastWin32Error() == CapiNative.ACCESS_DENIED)
                {
                    return IntPtr.Zero;
                }
    
                IntPtr certHandle = CapiNative.CertFindCertificateInStore(
                    storeHandle,
                    CapiNative.PKCS_7_ASN_ENCODING | CapiNative.X509_ASN_ENCODING,
                    0,
                    CapiNative.CERT_FIND_SUBJECT_STR,
                    "subject to find",
                    IntPtr.Zero);
    
                return certHandle;
            }
        }
    }
    
