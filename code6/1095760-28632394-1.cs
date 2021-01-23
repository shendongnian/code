    public class Program
    {
        A a = new A(); // You instantiated your object, i will be assigned 12
        Console.WriteLine(a.i.ToString() + "" + a.j.ToString()); 
        // Your output will be 12 0 because you didn't initialize j so the default is 0
        Console.ReadLine();
    }
