    class Program
        {
            static async void Main(string[] args)
            {
                var t = YourVoidMethod();
                await t;
            }
    
            static Task YourVoidMethod()
            {
                var task = new Task(() =>
                    {
                        // Your payload code
                    }
                );
    
                task.Start();
                return task;
                
            }
        }
