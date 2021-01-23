    using SV.Controllers;
    
    namespace SV.Controllers2
    {
      public class VMController2 : Controller
      {
        public void NewMethod()
        { 
            //instanciate vms here....
            IEnumerable<VM> vms;
            VMController controller = new VmController();
            controller.populateViewData(vms);
        }
      }
    }
