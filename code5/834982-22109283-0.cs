    using System.Collections.Generic;
    using System.Linq;
    namespace MyApp
    {
        using System.Reflection;
        using MyApp.Commands;
        class Program
        {
            static void Main(string[] args)
            {
                var methods = new MyCommands();
                MethodInfo myMethod;
                myMethod = CommandFactory.GetCommandMethod("Show Commands");
                myMethod.Invoke(methods, null);
                myMethod = CommandFactory.GetCommandMethod("Close window");
                myMethod.Invoke(methods, null);
                myMethod = CommandFactory.GetCommandMethod("Switch window");
                myMethod.Invoke(methods, null);
            }
        }
        public static class CommandFactory
        {
            private static Dictionary<string, MethodInfo> speechMethods = new Dictionary<string, MethodInfo>();
            public static MethodInfo GetCommandMethod(string commandText)
            {
                MethodInfo methodInfo;
                var commands = new MyCommands();
                if (speechMethods.Count == 0)
                {
                    var methodNames =
                        typeof(MyCommands).GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
                    var speechAttributeMethods = methodNames.Where(y => y.GetCustomAttributes().OfType<CommandAttribute>().Any());
                    foreach (var speechAttributeMethod in speechAttributeMethods)
                    {
                        foreach (var attribute in speechAttributeMethod.GetCustomAttributes(true))
                        {
                            speechMethods.Add(((CommandAttribute)attribute).Command, speechAttributeMethod);
                        }
                    }
                    methodInfo = speechMethods[commandText];
                }
                else
                {
                    methodInfo = speechMethods[commandText];
                }
                return methodInfo;
            }
        }
    }
    namespace MyApp.Commands
    {
        class MyCommands
        {
            [Command("Show All")]
            [Command("Show All Commands")]
            [Command("Show commands")]
            public void ShowAll()
            {
                ProgramCommands.ShowAllCommands();
            }
            [Command("Close Window")]
            public void CloseWindow()
            {
                ControlCommands.CloseWindow();
            }
            [Command("Switch Window")]
            public void SwitchWindow()
            {
                ControlCommands.SwitchWindow();
            }
        }
        [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = true)]
        public class CommandAttribute : System.Attribute
        {
            public string Command
            {
                get;
                set;
            }
            public CommandAttribute(string textValue)
            {
                this.Command = textValue;
            }
        }
    }
