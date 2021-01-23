    [System.Security.SecuritySafeCritical]  // auto-generated
            [ResourceExposure(ResourceScope.Machine)]
            [ResourceConsumption(ResourceScope.Machine)]
            public static String GetEnvironmentVariable(String variable)
            {
                if (variable == null)
                    throw new ArgumentNullException("variable");
                Contract.EndContractBlock();
     
    #if !FEATURE_CORECLR
                (new EnvironmentPermission(EnvironmentPermissionAccess.Read, variable)).Demand();
    #endif //!FEATURE_CORECLR
                
                StringBuilder blob = new StringBuilder(128); // A somewhat reasonable default size
                int requiredSize = Win32Native.GetEnvironmentVariable(variable, blob, blob.Capacity); 
     
                if( requiredSize == 0) {  //  GetEnvironmentVariable failed
                    if( Marshal.GetLastWin32Error() == Win32Native.ERROR_ENVVAR_NOT_FOUND)
                        return null;
                }
     
                while (requiredSize > blob.Capacity) { // need to retry since the environment variable might be changed 
                    blob.Capacity = requiredSize;
                    blob.Length = 0;
                    requiredSize = Win32Native.GetEnvironmentVariable(variable, blob, blob.Capacity); 
                }
                return blob.ToString();
            }
