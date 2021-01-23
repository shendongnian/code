    public class MyInjector : LoopValueInjection
    {       
        //by default is return sourcePropertyValue; override to change behaviour 
        protected override object SetValue(ConventionInfo c)
        {
            // this is just a sample, but you could write anything here
            return new Dest 
            { 
                //Check if source value is true and only then set property
                if(c.SourceProp.Name == "SetA")
                {
                  var setASourceVal = c.TargetProp.Value As bool;
                  if(setASourceVal)
                  {
                    A = sourcePropertyValue;
                  }
                }
            }
        }
    }
