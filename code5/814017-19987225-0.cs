    public class ExitProgramException : Exception { }
    public void SomeNestedStuff()
    {
        ...
        if (...) throw new ExitProgramException();
        ...
    }
    public void Main()
    {
        try 
        {
            ...
            SomeNestedStuff();
            ...
        }
        catch (ExitProgramException)
        {
            Console.WriteLine("Bye!");
        }
    }
