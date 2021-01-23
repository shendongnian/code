using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
[assembly:SecurityPermissionAttribute(SecurityAction.RequestMinimum,UnmanagedCode=true)]
[assembly:PermissionSetAttribute(SecurityAction.RequestMinimum, Name ="FullTrust")] 
public class ImpersonationDemo 
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SECURITY_ATTRIBUTES
    {
        public int Length;
        public IntPtr lpSecurityDescriptor;
        public bool bInheritHandle;
    }
    public enum SECURITY_IMPERSONATION_LEVEL
    {
        SecurityAnonymous,
        SecurityIdentification,
        SecurityImpersonation,
        SecurityDelegation
    }
    public enum TOKEN_TYPE
    {
        TokenPrimary = 1,
        TokenImpersonation
    } 
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    private unsafe static extern int FormatMessage(int dwFlags, ref IntPtr lpSource, int dwMessageId, int dwLanguageId, ref String lpBuffer, int nSize, IntPtr *Arguments);
    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public extern static bool CloseHandle(IntPtr handle);
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError=true)]
    public extern static bool DuplicateToken(IntPtr ExistingTokenHandle,  int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);
    [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public extern static bool DuplicateTokenEx( IntPtr hExistingToken, uint dwDesiredAccess, ref SECURITY_ATTRIBUTES lpTokenAttributes,
        SECURITY_IMPERSONATION_LEVEL ImpersonationLevel,
        TOKEN_TYPE TokenType,
        out IntPtr phNewToken);
    // GetErrorMessage formats and returns an error message
    // corresponding to the input errorCode.
    public unsafe static string GetErrorMessage(int errorCode)
    {
        int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
        int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
        int messageSize = 255;
        String lpMsgBuf = "";
        int dwFlags = FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS;
        IntPtr ptrlpSource = IntPtr.Zero;
        IntPtr prtArguments = IntPtr.Zero;
        int retVal = FormatMessage(dwFlags, ref ptrlpSource, errorCode, 0, ref lpMsgBuf, messageSize, &prtArguments);
        if (0 == retVal)
        {
            throw new Exception("Failed to format message for error code " + errorCode + ". ");
        }
    return lpMsgBuf;
    }
    // Test harness.
    // If you incorporate this code into a DLL, be sure to demand FullTrust.
    [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
    public static void Main(string[] args)
    {
        IntPtr tokenHandle = new IntPtr(0);
        IntPtr dupeTokenHandle = new IntPtr(0);
        try
        {
            string UserName, MachineName;
            // Get the user token for the specified user, machine, and password using the
            // unmanaged LogonUser method.
            Console.Write("Enter the name of a machine on which to log on: ");
            MachineName = Console.ReadLine();
            Console.Write("Enter the login of a user on {0} that you wish to impersonate: ", MachineName);
            UserName = Console.ReadLine();
            Console.Write("Enter the password for {0}: ", UserName);
            const int LOGON32_PROVIDER_DEFAULT = 3;
            //This parameter causes LogonUser to create a primary token.
            const int LOGON32_LOGON_INTERACTIVE = 8;
            tokenHandle = IntPtr.Zero;
            dupeTokenHandle = IntPtr.Zero;
            // Call LogonUser to obtain a handle to an access token.
            bool returnValue = LogonUser(UserName, MachineName, "mm4geata", 
                LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref tokenHandle);
            Console.WriteLine("LogonUser called.");
            if (false == returnValue)
            {
                int ret = Marshal.GetLastWin32Error();
                Console.WriteLine("LogonUser failed with error code : {0}", ret);
                Console.WriteLine("\nError: [{0}] {1}\n", ret, GetErrorMessage(ret));
                return;
            }
            Console.WriteLine("Did LogonUser Succeed? " + (returnValue? "Yes" : "No"));
            Console.WriteLine("Value of Windows NT token: " + tokenHandle);
            // Check the identity.
            Console.WriteLine("Before impersonation: " + WindowsIdentity.GetCurrent().Name);
            //bool retVal = DuplicateToken(tokenHandle, SecurityImpersonation, ref dupeTokenHandle);
            SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
            sa.bInheritHandle = true;
            sa.Length = Marshal.SizeOf(sa);
            sa.lpSecurityDescriptor = (IntPtr)0;
            bool retVal = DuplicateTokenEx(tokenHandle, 0x10000000, ref sa, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, TOKEN_TYPE.TokenImpersonation, out dupeTokenHandle); 
            if (false == retVal)
            {
                CloseHandle(tokenHandle);
                Console.WriteLine("Exception thrown in trying to duplicate token.");
                return;
            }
            // The token that is passed to the following constructor must
            // be a primary token in order to use it for impersonation.
            WindowsIdentity newId = new WindowsIdentity(dupeTokenHandle);
            WindowsImpersonationContext impersonatedUser = newId.Impersonate();
            // Check the identity.
            Console.WriteLine("After impersonation: " + WindowsIdentity.GetCurrent().Name);
            // Stop impersonating the user.
            impersonatedUser.Undo();
            // Check the identity.
            Console.WriteLine("After Undo: " + WindowsIdentity.GetCurrent().Name);
            // Free the tokens.
            if (tokenHandle != IntPtr.Zero)
            CloseHandle(tokenHandle);
            if (dupeTokenHandle != IntPtr.Zero)
            CloseHandle(dupeTokenHandle);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Exception occurred. " + ex.Message);
        }
    }
}
