    public class TestClass
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public DateTime Dob { get; set; }
    
            public void YourMethod()
            {
                List<TestClass> temp = new List<TestClass>();
    
                var x = from xyz in temp
                        where xyz.Name == "Name" && xyz.Id == new Guid()
                        select xyz.Dob;
            }
        }
