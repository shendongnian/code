    public static string getName(TestClass testClass)
    {
            try
            {
                //functionality goes here
                throw new Exception(); // just for demo purposes, throw an exception here
                return testClass.Name;                
            }
            catch (Exception ex)
            {
                throw new MyException(testClass);
            }
    }
