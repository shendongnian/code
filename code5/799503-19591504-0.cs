    public class BaseVMController : Controller
    {
      public virtual void PopulateViewData(IEnumerable<VM> vms)
      { 
          // ...
      }
    }
    public class VMController : BaseVMController 
    {
      public void NewMethod()
      { 
          IEnumerable<VM> vms;
          PopulateViewData(vms);
          // ...
      }
    }
    public class VMController2 : BaseVMController 
    {
      public void NewMethod2(IEnumerable<VM> vms)
      { 
          PopulateViewData(vms);
          // ...
      }
    }
