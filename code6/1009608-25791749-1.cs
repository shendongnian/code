    public abstract class ISystem
    {
        public abstract void DoSomething();
    }
    public class ThisThing : ISystem
    {
        public override void DoSomething()
        {
            Console.WriteLine("Do This Thing");
        }
    }
    public class ThatThing : ISystem
    {
        public override void DoSomething()
        {
            Console.WriteLine("Do That Thing");
        }
    }
    static void Main(string[] args)
    {
        var input = "-1";
        while(/*input is invalid*/)
        {
            // get input from user
        }
        var thisThing = new ThisThing();
        var thatThing = new ThatThing();
        switch(input)
        {
            case "1":
               {
                   thisThing.DoSomething();
                   break;
               }
            case "2":
               {
                   thatThing.DoSomething();
                   break;
               }
            case "0":
               {
                   var commands = new List<ISystem>();
                   commands.Add(thisThing);
                   commands.Add(thatThing);
                   // Execute all commands
                   commands.ForEach(system => system.DoSomething());
                   break;
               }
        }
    }
