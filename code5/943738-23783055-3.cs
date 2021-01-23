     static void Main(string[] args)
        {
            var list = new List<TestClass>() { new TestClass() { Id = 1, Name= "name", Number= 789} };
            try
            {
                var test = (from values in list
                           select new
                           {
                               Id = values.Id,
                               Name = getName(values),
                           }).ToList();
            }
            catch (MyException ex)
            {
                //I want to use "Number" here!
                var number = ex.TestClass.Number;
                throw ex;
            }  
        }
