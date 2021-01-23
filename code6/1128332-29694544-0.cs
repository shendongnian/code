    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace UnitTestProject2
    {
        class Class4
        {
            public void run()
            {
                List<String> Arguments = new List<String> { "AA", "BB", "CC" };
                List<Task<String>> tasks = new List<Task<string>>();
    
                foreach (string arg in Arguments)
                {
                        tasks.Add(
                            this.DoSomething(arg)
                            .ContinueWith(t => this.DoSomething(t.Result))
                            .Unwrap<string>()
                        );
                }
    
                Task.WaitAll(tasks.ToArray());
    
                foreach(Task<string> t in tasks)
                {
                    textBox1 += (t.Result + Environment.NewLine + Environment.NewLine);
                }
    
            }
    
            public async Task<string> DoSomething(string arg)
            {
                return arg;
            }
    
            public string textBox1;
        }
    }
