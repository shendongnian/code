    //Make sure to add a reference to System.Management; 
    
    
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Management;
    using System.Security.Principal;
    using System.Collections;
    using System.Runtime.InteropServices;
    
    
    
    namespace RealUSer
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //Getting the session id
                int session = System.Diagnostics.Process.GetCurrentProcess().SessionId;
                //Getting the username related to the session id 
                string user = GetUsernameBySessionId(session, false);
                try
                {
                    //Cheching if the user belongs to the local admin group using wmi
                    if (CheckAdminRights(user))
                    {
                        MessageBox.Show("The logged in User "+user+" is an Admin");
                    }
                    else
                    {
                        MessageBox.Show("The logged in User " + user + " is not an Admin");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
    
                }
    
            }
            /// <summary>
            /// This method checks if the context user, belongs to the local administrators group
            /// </summary>
            /// <param name="username"></param>
            /// <returns></returns>
    
            public  bool CheckAdminRights(string username)
            {
                bool result = false;
                List<string> admins = new List<string>();
                //SelectQuery query = new SelectQuery("Select AccountType from Win32_UserAccount where Name=\"" + username + "\"");
                SelectQuery query = new SelectQuery("SELECT * FROM win32_group WHERE Name=\"" + getAdministratorGroupName() + "\"");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection OC = searcher.Get();
                IEnumerator enumerator = OC.GetEnumerator();
                enumerator.MoveNext();
                ManagementObject O = (ManagementObject)enumerator.Current;
                ManagementObjectCollection adminusers = O.GetRelated("Win32_UserAccount");
                foreach (ManagementObject envVar in adminusers)
                {
                    admins.Add(envVar["Name"].ToString());
                    //Console.WriteLine("Username : {0}", envVar["Name"]);
                    //foreach (PropertyData pd in envVar.Properties)
                    //    Console.WriteLine(string.Format("  {0,20}: {1}", pd.Name, pd.Value));
                }
                if (admins.Contains(username))
                    result = true;
                return result;
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///This code will find the administrators group name, independent of the OS language using the LookupAccountSid function with the BUILTIN\Administrators sid
    
            #region
    
    
            const int NO_ERROR = 0;
            const int ERROR_INSUFFICIENT_BUFFER = 122;
    
            enum SID_NAME_USE
            {
                SidTypeUser = 1,
                SidTypeGroup,
                SidTypeDomain,
                SidTypeAlias,
                SidTypeWellKnownGroup,
                SidTypeDeletedAccount,
                SidTypeInvalid,
                SidTypeUnknown,
                SidTypeComputer
            }
    
            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern bool LookupAccountSid(
              string lpSystemName,
              [MarshalAs(UnmanagedType.LPArray)] byte[] Sid,
              StringBuilder lpName,
              ref uint cchName,
              StringBuilder ReferencedDomainName,
              ref uint cchReferencedDomainName,
              out SID_NAME_USE peUse);
    
            public  string getAdministratorGroupName()
            {
                String result = "";
                StringBuilder name = new StringBuilder();
                uint cchName = (uint)name.Capacity;
                StringBuilder referencedDomainName = new StringBuilder();
                uint cchReferencedDomainName = (uint)referencedDomainName.Capacity;
                SID_NAME_USE sidUse;
                // Sid for BUILTIN\Administrators
                byte[] Sid = new byte[] { 1, 2, 0, 0, 0, 0, 0, 5, 32, 0, 0, 0, 32, 2 };
    
                int err = NO_ERROR;
                if (!LookupAccountSid(null, Sid, name, ref cchName, referencedDomainName, ref cchReferencedDomainName, out sidUse))
                {
                    err = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                    if (err == ERROR_INSUFFICIENT_BUFFER)
                    {
                        name.EnsureCapacity((int)cchName);
                        referencedDomainName.EnsureCapacity((int)cchReferencedDomainName);
                        err = NO_ERROR;
                        if (!LookupAccountSid(null, Sid, name, ref cchName, referencedDomainName, ref cchReferencedDomainName, out sidUse))
                            err = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                    }
                }
                if (err == 0)
                {
                    result = name.ToString();
                }
    
                return result;
            }
    
            #endregion
    
           
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
    
    
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///This code will retrieve user name given the session id
    
            #region
            [DllImport("Wtsapi32.dll")]
            private static extern bool WTSQuerySessionInformation(IntPtr hServer, int sessionId, WTS_INFO_CLASS wtsInfoClass, out System.IntPtr ppBuffer, out int pBytesReturned);
            [DllImport("Wtsapi32.dll")]
            private static extern void WTSFreeMemory(IntPtr pointer);
    
            public static string GetUsernameBySessionId(int sessionId, bool prependDomain)
            {
                IntPtr buffer;
                int strLen;
                string username = "SYSTEM";
                if (WTSQuerySessionInformation(IntPtr.Zero, sessionId, WTS_INFO_CLASS.WTSUserName, out buffer, out strLen) && strLen > 1)
                {
                    username = Marshal.PtrToStringAnsi(buffer);
                    WTSFreeMemory(buffer);
                    if (prependDomain)
                    {
                        if (WTSQuerySessionInformation(IntPtr.Zero, sessionId, WTS_INFO_CLASS.WTSDomainName, out buffer, out strLen) && strLen > 1)
                        {
                            username = Marshal.PtrToStringAnsi(buffer) + "\\" + username;
                            WTSFreeMemory(buffer);
                        }
                    }
                }
                return username;
            }
            public enum WTS_INFO_CLASS
            {
                WTSInitialProgram,
                WTSApplicationName,
                WTSWorkingDirectory,
                WTSOEMId,
                WTSSessionId,
                WTSUserName,
                WTSWinStationName,
                WTSDomainName,
                WTSConnectState,
                WTSClientBuildNumber,
                WTSClientName,
                WTSClientDirectory,
                WTSClientProductId,
                WTSClientHardwareId,
                WTSClientAddress,
                WTSClientDisplay,
                WTSClientProtocolType
            }
            #endregion
        }
    }
