    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
    			var form = new Form { 
    			    WindowState = FormWindowState.Minimized, 
    			    ShowInTaskbar = false };
    
    			form.Shown += delegate 
    			{
    				Debug.Print("form.Shown");
    			};
    
    			form.Load += async delegate
    			{
    				Debug.Print("form.Load");
    
    				await Task.Delay(5000);
    
    				form.WindowState = FormWindowState.Normal;
    				form.ShowInTaskbar = true;
    				form.Show();
    			};
    
                Application.Run(form);
            }
        }
    }
