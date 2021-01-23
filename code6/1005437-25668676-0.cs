    void TheUnitTest()
    {
    	var p = new Person();
    	Assert.That(p.GetType().GetProperties().Count() == 3);
    }
    
    public class Person { public String Name{ get; set; } public int age { get; set; } public String job { get; set; } }
