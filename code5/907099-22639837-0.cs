     public class Job{
         [XmlIgnore]
         System.Diagnostics.Process process;
         public ProcessFileName
         {
             get {return process.StartInfo.FileName;}
             set { process = Process.Start(value); }
         }
     }
