    namespace ConsoleApplication2
    {
     class Program
     {
      static void Main(string[] args)
      {
       Process myProcess = new Process();
       myProcess.StartInfo.FileName = @"C:\Users\joseluis.vaquero\Documents\Visual Studio 2008\Projects\Prototipos\ConsoleApplication1\bin\Debug\ConsoleApplication1.exe";
       // myProcess.StartInfo.Arguments = "-yourArguments";
       myProcess.StartInfo.UseShellExecute = false;//do not open shell window
       myProcess.StartInfo.RedirectStandardOutput = true; // allows you to manipulate or suppress the output of a process
       myProcess.StartInfo.RedirectStandardInput = true;// allows you to manipulate or suppress the input of a process
       myProcess.Start();
       Thread.Sleep(1000);//maybe you have to wait a bit
       Console.WriteLine(myProcess.StandardOutput.ReadLine());
       myProcess.StandardInput.WriteLine("jlvaquero");//send user name to consoleapp1
       Thread.Sleep(1000);
       char[] myBuffer = new char[1];
       while (myBuffer[0] != ':') //read until double dot wich is the last char of "Password:"
       {
         myProcess.StandardOutput.Read(myBuffer, 0, 1);
        Console.Write(myBuffer[0]);
       }
       Console.WriteLine();//just to get readable output for the example
       myProcess.StandardInput.WriteLine("1234");//send pwd to consoleapp1
       Thread.Sleep(1000);
       Console.Write(myProcess.StandardOutput.ReadLine());//show the output of consoleapp1
       Console.Read();
      }
     }
    }
