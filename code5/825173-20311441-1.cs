    class Program
        {
            static void Main(string[] args)
            {
                DoWork();
            }
    
            static async void DoWork()
            {
                var t = YourVoidMethod();
                await t;
            }
    
            static Task YourVoidMethod()
            {
                var task = new Task(() =>
                    {
                        // Your work
                    }
                );
    
                task.Start();
                return task;
                
            }
        }
