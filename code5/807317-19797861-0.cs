    public interface IWorkerRule
        {
            string FormatText(string input);
        }
    
        internal class AdminRules : IWorkerRule
        {
            public string FormatText(string input)
            {
                return input.Replace("!", "?");
            }
        }
    
        internal class UserRules : IWorkerRule
        {
            public string FormatText(string input)
            {
                return input.Replace("!", ".");
            }
        }
    
        public class Worker
        {
            private IWorkerRule Rule { get; set; }
    
            public Worker(IWorkerRule rule)
            {
                Rule = rule;
            }
    
            public string FormatText(string text)
            {
                //generic shared formatting applied to any consumer
                text = text.Replace("@", "*");
    
                //here we apply the injected logic 
                text = Rule.FormatText(text);
                return text;
            }
        }
    
        class Program
        {       
            //injecting admin functions
            static void Main()
            {
                const string sampleText = "This message is @Important@ please do something about it!";
                
                //inject the admin rules.
                var worker = new Worker(new AdminRules());
                Console.WriteLine(worker.FormatText(sampleText));
    
                //inject the user rules
                worker = new Worker(new UserRules());
                Console.WriteLine(worker.FormatText(sampleText));
    
                Console.ReadLine();
    
            }
    
        }
