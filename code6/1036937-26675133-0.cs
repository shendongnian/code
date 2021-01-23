    public class MyTask: AsyncTask<string, int, int>
        {
            protected MyTask(IntPtr javaReference, JniHandleOwnership transfer)
                : base(javaReference, transfer)
            {
                
            }
            public MyTask()
            {
                
            }
    
            protected override int RunInBackground(params string[] @params)
            {
                return 4;
            }
    
            protected override void OnPostExecute(int result)
            {
                System.Console.WriteLine("On post execute");
                base.OnPostExecute(result);
            }
        }
