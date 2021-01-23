    TestRunner.TestDLLString = getDLL(project);
                var TestDLL = Assembly.LoadFrom(TestDLLString);
                Type myClassType = TestDLL.GetType("SeleniumDPS." + testname);
                var instance = Activator.CreateInstance(myClassType);
                MethodInfo myInitMethod = myClassType.GetMethod("Initialize");
                try
                {
                    myInitMethod.Invoke(instance, null);
                }
                catch (Exception ex)
                {
    //Error logging etc
                }
