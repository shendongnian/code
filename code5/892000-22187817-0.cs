    using System.IO;
    using System;
    using System.Security.Principal;
    class Program
    {
        static void Main()
        {
            Console.WriteLine(WindowsIdentity.GetCurrent().Name);
        }
    }
