    public void test()
    {
      A originalProcess = new A();
      originalProcess.subProcess.someBoolean = false;
      Type originalProcessType = originalProcess.GetType();
      PropertyInfo selectedSubProcess = originalProcessType.GetProperty("subProcess");
      object subProcess = selectedSubProcess.GetValue(originalProcess, null);
      Type subType = selectedSubProcess.PropertyType;
      PropertyInfo prop = subType.GetProperty("someBoolean");
      if (prop != null)
      {
        prop.SetValue(subProcess, true, null);
      }
      MessageBox.Show(originalProcess.subProcess.someBoolean.ToString());
    }
    public class A
    {
      private B pSubProcess = new B();
      public B subProcess
      {
        get
        {
          return pSubProcess;
        }
        set
        {
          pSubProcess = value;
        }
      }
    }
    
    public class B
    {
      private bool pSomeBoolean = false;
      public bool someBoolean
      {
        get
        {
          return pSomeBoolean;
        }
        set
        {
          pSomeBoolean = true;
        }
      }
    }
