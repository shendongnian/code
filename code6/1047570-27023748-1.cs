    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using Shell32;
    namespace ConsoleApplication1
    {
    class Program
    {
    static void Main(string[] args)
    {
      double contartiempo = 0;
      //Shell32.Shell shell = new Shell32.Shell();
      Shell32.Folder carpeta;
      carpeta = GetShell32Folder(@"D:\");
      foreach (Shell32.FolderItem2 item in carpeta.Items()) {
        Console.WriteLine(carpeta.GetDetailsOf(item, 27));
        TimeSpan tiempo = TimeSpan.Parse(carpeta.GetDetailsOf(item, 27));
        contartiempo += tiempo.TotalSeconds;
      }
      Console.WriteLine("El total de tiempo de los videos es: " + contartiempo);
      Console.ReadLine();
    }
    private static Shell32.Folder GetShell32Folder(string folderPath)
    {
      Type shellAppType = Type.GetTypeFromProgID("Shell.Application");
      Object shell = Activator.CreateInstance(shellAppType);
      return (Shell32.Folder)shellAppType.InvokeMember("NameSpace",
      System.Reflection.BindingFlags.InvokeMethod, null, shell, new object[] { folderPath     });
    }
      }
    }
