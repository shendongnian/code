    class Program
        {
            static void Main(string[] args)
            {
                DoWork();
            }
    
            static async void DoWork()
            {
                await YourVoidMethod();
            }
    
            static Task YourVoidMethod()
            {
                Task task = Task.Factory.StartNew(() =>
                    {
                        // Your payload code
                    }
                );
    
                return task; 
            }
        }
