     class Employee
    {
    public string FName;
    public string LName;
    public virtual  void Print()
    {
        Console.WriteLine(FName + " " + LName);
    }
    }
    class FullTimeEmployee : Employee
    {
        public override  void Print()
         {
        Console.WriteLine(FName + " " + LName + " - From FullTimeEmployee Class . . .");
       }
    }
    class PartTimeEmployee : Employee
    {
    }
    class Program
    {
    static void Main()
    {
        FullTimeEmployee FTE = new FullTimeEmployee();
        FTE.FName = "FullTime";
        FTE.LName = "Employee";
        FTE.Print();
        PartTimeEmployee PTE = new PartTimeEmployee();
        PTE.FName = "PartTime";
        PTE.LName = "Employee";
        PTE.Print();
        Console.Read();
    }
    }
