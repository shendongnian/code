    class Program
    {
            static void Main(string[] args)
            {
                RunnerClass runner = new RunnerClass();
                
                runner.runProgram += (exeFile) => Process.Start("your.exe");
                string runApp = "run.exe";
                runner.runProgram(runApp);
            }
    }
    public class RunnerClass
    {
       public Action<string> runProgram;
    }    
     
