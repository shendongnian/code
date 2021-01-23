    using System.Diagnostics;
    using System.EnterpriseServices;
    using System.Runtime.InteropServices;
    [assembly: ApplicationActivation(ActivationOption.Server)]
    [assembly: ApplicationAccessControl(false)]
    
    namespace SingleUseServer
    {
        [ComVisible(true)]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [Guid("6C3295E3-D9C9-40E3-AFBD-1398D4D1E344")]
        public interface IService
        {
            int GetProcessId();
        }
    
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        [ProgId("Test.Service")]
        [Guid("6B198197-3E88-4429-883D-A818E4E447D3")]
        public class Service : ServicedComponent, IService
        {
            public int GetProcessId()
            {
                return Process.GetCurrentProcess().Id;
            }
        }
    }
