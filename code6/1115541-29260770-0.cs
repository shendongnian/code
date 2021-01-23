    using System;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;
    
    namespace WhatEverYouUse {
        class Program : WindowsFormsApplicationBase {
            [STAThread]
            static void Main(string[] args) {
                Application.SetCompatibleTextRenderingDefault(false);
                new Program().Start(args);
            }
            void Start(string[] args) {
                this.EnableVisualStyles = true;
                this.IsSingleInstance = true;
                this.MainForm = new Form1();
                this.Run(args);
            }
            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs) {
                this.MainForm.WindowState = FormWindowState.Normal;
                this.MainForm.BringToFront();
            }
        }
    }
