    using System;
    namespace EATest {
      class Program {
        public static void Main(string[] args) {
          Console.WriteLine("Hello World!");
          EA.Repository r = new EA.Repository();
          bool isOpen = r.OpenFile("C:\\temp\\Sparx-EA\\Sample Project.eap");
          r.ShowWindow(1);
          Console.Write("Press any key to continue . . . ");
          Console.ReadKey(true);
        }
      }
    }
