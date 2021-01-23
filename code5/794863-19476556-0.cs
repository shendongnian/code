    public class Human
    {
        virtual public void DisplayLanguage() { Console.WriteLine("I  do speak a language"); }
    }
    public class Asian : Human
    {
        override public void DisplayLanguage() { Console.WriteLine("I speak chinesse"); }
    }
    public class European : Human
    {
        override public void DisplayLanguage() { Console.WriteLine("I speak romanian"); }
    }
