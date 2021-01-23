    class TestA : BaseTestClass<SettingsA>
    {
       //Works!
       public override void Run(BaseDataClass<SettingsA> data)
       {
            var myDataA = data as DataA;
            if (myDataA != null)
            {
                //your parameter is a DataA;
            }
       }
    }
