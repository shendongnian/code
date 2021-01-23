    public abstract class BaseTest<TSettings> where TSettings : BaseTestSettings
    {
       public TSettings Settings{get;set;}
       public abstract void Run();
    }
    
    public class BaseTestSettings
    {
       public double SettingsProp1{get;set;}
       public double SettingsProp1{get;set;}
    }
    
    public class SpecializaedTestSettings : BaseTestSettings
    {
       public double SpecializaedTestSettingsPropA{get;set;}
       public double SpecializaedTestSettingsPropB{get;set;}
    }
    
    public class SpecializaedTest : BaseTest<SpecializaedTestSettings>
    {
       public SpecializaedTest()
       {
          this.Settings = new SpecializaedTestSettings();
       }
    
       public override void Run()
       {
          SpecializaedTestSettings settings = this.Settings;
       }
    }
