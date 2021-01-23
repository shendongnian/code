    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Program
    {
       static void Main(string[] args)
       {
          // Use file to make binding data decision, 
          //  avoid duplicate binding due to page reload:
          using (var fileStream =
              File.Open("a.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
          {
             // read from the file
             var streamReader = new StreamReader(fileStream);
             string line = streamReader.ReadLine();
             if (line == "NO")
             {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                   streamWriter.WriteLine("YES");
                   streamWriter.Close();
                }
             }
             else
             {
                // If now is a loop then write NO to the file
                using (var streamWriter = new StreamWriter(fileStream))
                {
                   streamWriter.WriteLine("NO");
                   streamWriter.Close();
                }
             }
          }
       }
    }
