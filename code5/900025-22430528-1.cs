    using System;
    using System.Windows.Forms;
    public static class Program {
        public static void Main(string args) {
            if (string.IsNullOrEmpty(args)) {
                // Run your Main Form
                // (blocks until Form1 is closed)
                Application.Run(new Form1());
            }
            else {
                // Run the context menu action
                fileCopytoDirA(args);
            }
            // exit
        }
    }
