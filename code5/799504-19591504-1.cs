    public abstract class BaseVMController : Controller
    {
      protected virtual void PopulateViewData(IEnumerable<VM> vms)
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
      protected override void PopulateViewData(IEnumerable<VM> vms)
      { 
          base.PopulateViewData(vms);
          // some additional behavior ...
      }
    }
