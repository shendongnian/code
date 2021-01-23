    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
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
                Application.Run(new MyForm());
            }
        }
    
        public class MyForm : Form
        {
            public MyForm()
            {
                //InitializeComponent();
            }
    
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
    
                Graphics gfx = e.Graphics;
                gfx.DrawRectangle(Pens.Black, 10f, 10f, 10f, 10f);
            }
        }
    }
