    namespace NUnitGuiRunner
    {
        using System;
        using System.Windows.Forms;
    
        using System.Diagnostics;
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void RunTestsButton_Click(object sender, EventArgs e)
            {
                Process.Start(@"C:\NUnit 2.6.2\bin\nunit.exe", @"C:\PathToTests\SomeUnitTests.dll");
            }
        }
    }
