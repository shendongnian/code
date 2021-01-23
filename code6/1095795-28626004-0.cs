            [Test]
            public void T1()
            {
    
                var type = typeof (classwithListmethod);
    
                MethodInfo methodInfo = type.GetMethod("List");
                object classInstance = Activator.CreateInstance(type, null);
    
                var list = new List<string>(){"one","two"};
                var a = methodInfo.Invoke(classInstance, new []{list});
            }
    
    
            public class classwithListmethod
            {
                public void List(List<string> s)
                {
                    foreach (var ss in s)
                    {
                        Console.WriteLine(ss);
                    }
                }
    
            }
