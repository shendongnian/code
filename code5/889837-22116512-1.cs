    using System;
    using System.Diagnostics;
    
    class Program {
        static void Main(string[] args) {
            var psi = new ProcessStartInfo("notepad.exe");
            //psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(psi);
        }
    }
