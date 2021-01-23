    class Entry
    {
    
        const uint NO_ERROR = 0;
        [DllImport("ntdsapi.dll", CharSet = CharSet.Auto)]
        static public extern uint DsCrackNames(
          IntPtr hDS,
          DS_NAME_FLAGS flags,
          DS_NAME_FORMAT formatOffered,
          DS_NAME_FORMAT formatDesired,
          uint cNames,
          string[] rpNames,
          out IntPtr ppResult  // PDS_NAME_RESULT
          );
    
        [DllImport("ntdsapi.dll", CharSet = CharSet.Auto)]
        static public extern void DsFreeNameResult(IntPtr pResult /* DS_NAME_RESULT* */);
    
        public enum DS_NAME_ERROR
        {
            DS_NAME_NO_ERROR = 0,
    
            // Generic processing error.
            DS_NAME_ERROR_RESOLVING = 1,
    
            // Couldn't find the name at all - or perhaps caller doesn't have
            // rights to see it.
            DS_NAME_ERROR_NOT_FOUND = 2,
    
            // Input name mapped to more than one output name.
            DS_NAME_ERROR_NOT_UNIQUE = 3,
    
            // Input name found, but not the associated output format.
            // Can happen if object doesn't have all the required attributes.
            DS_NAME_ERROR_NO_MAPPING = 4,
    
            // Unable to resolve entire name, but was able to determine which
            // domain object resides in.  Thus DS_NAME_RESULT_ITEM?.pDomain
            // is valid on return.
            DS_NAME_ERROR_DOMAIN_ONLY = 5,
    
            // Unable to perform a purely syntactical mapping at the client
            // without going out on the wire.
            DS_NAME_ERROR_NO_SYNTACTICAL_MAPPING = 6,
    
            // The name is from an external trusted forest.
            DS_NAME_ERROR_TRUST_REFERRAL = 7
    
        }
    
        [Flags]
        public enum DS_NAME_FLAGS
        {
            DS_NAME_NO_FLAGS = 0x0,
    
            // Perform a syntactical mapping at the client (if possible) without
            // going out on the wire.  Returns DS_NAME_ERROR_NO_SYNTACTICAL_MAPPING
            // if a purely syntactical mapping is not possible.
            DS_NAME_FLAG_SYNTACTICAL_ONLY = 0x1,
    
            // Force a trip to the DC for evaluation, even if this could be
            // locally cracked syntactically.
            DS_NAME_FLAG_EVAL_AT_DC = 0x2,
    
            // The call fails if the DC is not a GC
            DS_NAME_FLAG_GCVERIFY = 0x4,
    
            // Enable cross forest trust referral
            DS_NAME_FLAG_TRUST_REFERRAL = 0x8
    
        }
    
        public enum DS_NAME_FORMAT
        {
            // unknown name type
            DS_UNKNOWN_NAME = 0,
    
            // eg: CN=User Name,OU=Users,DC=Example,DC=Microsoft,DC=Com
            DS_FQDN_1779_NAME = 1,
    
            // eg: Example\UserN
            // Domain-only version includes trailing '\\'.
            DS_NT4_ACCOUNT_NAME = 2,
    
            // Probably "User Name" but could be something else.  I.e. The
            // display name is not necessarily the defining RDN.
            DS_DISPLAY_NAME = 3,
    
            // obsolete - see #define later
            // DS_DOMAIN_SIMPLE_NAME = 4,
    
            // obsolete - see #define later
            // DS_ENTERPRISE_SIMPLE_NAME = 5,
    
            // String-ized GUID as returned by IIDFromString().
            // eg: {4fa050f0-f561-11cf-bdd9-00aa003a77b6}
            DS_UNIQUE_ID_NAME = 6,
    
            // eg: example.microsoft.com/software/user name
            // Domain-only version includes trailing '/'.
            DS_CANONICAL_NAME = 7,
    
            // eg: usern@example.microsoft.com
            DS_USER_PRINCIPAL_NAME = 8,
    
            // Same as DS_CANONICAL_NAME except that rightmost '/' is
            // replaced with '\n' - even in domain-only case.
            // eg: example.microsoft.com/software\nuser name
            DS_CANONICAL_NAME_EX = 9,
    
            // eg: www/www.microsoft.com@example.com - generalized service principal
            // names.
            DS_SERVICE_PRINCIPAL_NAME = 10,
    
            // This is the string representation of a SID.  Invalid for formatDesired.
            // See sddl.h for SID binary <--> text conversion routines.
            // eg: S-1-5-21-397955417-626881126-188441444-501
            DS_SID_OR_SID_HISTORY_NAME = 11,
    
            // Pseudo-name format so GetUserNameEx can return the DNS domain name to
            // a caller.  This level is not supported by the DS APIs.
            DS_DNS_DOMAIN_NAME = 12
        }
    
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DS_NAME_RESULT_ITEM
        {
            public DS_NAME_ERROR status;
            public string pDomain;
            public string pName;
        }
    
        [DllImport("ntdsapi.dll", CharSet = CharSet.Auto)]
        static public extern uint DsBind(
          string DomainControllerName,      // in, optional
          string DnsDomainName,         // in, optional
          out IntPtr phDS);
    
        [DllImport("ntdsapi.dll", CharSet = CharSet.Auto)]
        static public extern uint DsUnBind(ref IntPtr phDS);
    
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DS_NAME_RESULT
        {
            public uint cItems;
            public IntPtr rItems; // PDS_NAME_RESULT_ITEM
        }
    
        [STAThread]
        static void Main(string[] args)
        {
            // Bind to default global catalog
            IntPtr hDS;
            uint err = DsBind(null, null, out hDS);
            if (err != NO_ERROR)
            {
                Console.WriteLine("Error on DsBind : {0}", err);
                return;
            }
            // Crack the currently logged on name
            try
            {
                string[] names = new string[] { System.Security.Principal.WindowsIdentity.GetCurrent().Name };
                DS_NAME_RESULT_ITEM[] results =
                  HandleDsCrackNames(hDS, DS_NAME_FLAGS.DS_NAME_NO_FLAGS, DS_NAME_FORMAT.DS_NT4_ACCOUNT_NAME, DS_NAME_FORMAT.DS_USER_PRINCIPAL_NAME, names);
                foreach (DS_NAME_RESULT_ITEM result in results)
                {
                    Console.WriteLine("Result : {0}\r\nDomain : {1}\r\nName : {2}", result.status, result.pDomain, result.pName);
                }
            }
            finally
            {
                DsUnBind(ref hDS);
            }
        }
    
        /// <summary>
        /// A wrapper function for the DsCrackNames OS call
        /// </summary>
        /// <param name="hDS">DsBind handle</param>
        /// <param name="flags">Flags controlling the process</param>
        /// <param name="formatOffered">Format of the names</param>
        /// <param name="formatDesired">Desired format for the names</param>
        /// <param name="names">The names to crack</param>
        /// <returns>The crack result</returns>
        public static DS_NAME_RESULT_ITEM[] HandleDsCrackNames(IntPtr hDS, DS_NAME_FLAGS flags, DS_NAME_FORMAT formatOffered, DS_NAME_FORMAT formatDesired, string[] names)
        {
            IntPtr pResult;
            DS_NAME_RESULT_ITEM[] ResultArray;
            uint err = DsCrackNames(
          hDS,
          flags,
          formatOffered,
          formatDesired,
          (uint)((names == null) ? 0 : names.Length),
          names,
          out pResult);
            if (err != NO_ERROR)
                throw new System.ComponentModel.Win32Exception((int)err);
            try
            {
                // Next convert the returned structure to managed environment
                DS_NAME_RESULT Result = new DS_NAME_RESULT();
                Result.cItems = (uint)Marshal.ReadInt32(pResult);
                Result.rItems = Marshal.ReadIntPtr(pResult, Marshal.OffsetOf(typeof(DS_NAME_RESULT), "rItems").ToInt32());
                IntPtr curptr = Result.rItems;
                ResultArray = new DS_NAME_RESULT_ITEM[Result.cItems];
                for (int index = 0; index < (int)Result.cItems; index++)
                {
                    ResultArray[index] = (DS_NAME_RESULT_ITEM)Marshal.PtrToStructure(curptr, typeof(DS_NAME_RESULT_ITEM));
                    curptr = (IntPtr)((int)curptr + Marshal.SizeOf(ResultArray[index]));
                }
            }
            finally
            {
                DsFreeNameResult(pResult);
            }
            return ResultArray;
        }
    
    }
