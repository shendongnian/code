        [DllExport("GetInformationEx", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static int GetInformationEx([MarshalAs(UnmanagedType.AnsiBStr)] out string strout)
        {
            int returnCode = 0; //success
            try
            {
                string something = "ladida";
                strout = something;
            }
            catch 
            {
                strout = "";
                returnCode = 1; //Error
            }
            return returnCode; 
        }
