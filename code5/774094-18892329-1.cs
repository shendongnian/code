    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var cmd = Empty_Command.FindCommand("command_2");
                if (cmd != null)
                    Console.WriteLine(cmd.command_display_name);
                Console.ReadKey();
    
    
            }
        }
    
        public abstract class Empty_Command
        {
            /// <summary>
            /// Find command
            /// </summary>
            /// <param name="commandName">the command name</param>
            /// <returns></returns>
            public static Empty_Command FindCommand(string commandName)
            {
                //get all the types that are inherited from the Empty_Command class and are not abstract (skips empty commad)
                var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => typeof(Empty_Command).IsAssignableFrom(x) && !x.IsAbstract);
                //enuerate all types
                foreach (var type in types)
                {
                    //create an instance of empty command from the type
                    var item = Activator.CreateInstance(type) as Empty_Command;
                    if (item == null)
                        continue;
                    //test the display name
                    if(item.command_display_name.Equals(commandName))
                        return item;
                }
                return null;
            }
            public abstract string command_display_name { get; }
        }
    
        public class Command1 : Empty_Command
        {
            public override string command_display_name
            {
                get { return "command_1"; }
            }
        }
    
        public class Command2 : Empty_Command
        {
            public override string command_display_name
            {
                get { return "command_2"; }
            }
        }
    
        public class Command3 : Empty_Command
        {
            public override string command_display_name
            {
                get { return "command_3"; }
            }
        }
    }
