    public class Example
                    {
                        public string Value;
        
                        public void SomeMethod()
                        {
                        
                        }
                    }           
        
         IList<Example> someCollection = new List<Example>()
                    {
                        new Instance() {Value = "1",},
                        new Instance() {Value = "2"}
                    };
        
                    foreach (Example instance in someCollection.Where(instance => instance.Value == "1"))
                    {
                        instance.SomeMethod();
                    }  
