    public interface IPerson
    {
        string Name { get; set; }
        int Id { get; set; }
    }
    class Student : IPerson
    {
       /* implement the properties */
    }
    class Employees : IPerson
    {
        /* implement the properties */
    }
    static void Main(string[] args)
    {
        List<IPerson> personList = new List<IPerson>();
        personList.Add(new Student {/* set properties */});
        personList.Add(new Employee {/* set properties */});
        //  use a loop and display your properties without casting
    }
    
 
