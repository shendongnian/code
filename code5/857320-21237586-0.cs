    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        using System.Runtime.InteropServices;
        public partial class Form1 : Form
        {
            // This nested class must be ComVisible for the JavaScript to be able to call it.
            [ComVisible(true)]
            public class ScriptManager
            {
                // Variable to store the form of type Form1.
                private Form1 mForm;
    
                // Constructor.
                public ScriptManager(Form1 form)
                {
                    // Save the form so it can be referenced later.
                    mForm = form;
                }
    
                public void AnotherMethod(string message)
                {
                    MessageBox.Show(message);
                    mForm.GoToNext();
                }
            }
            public Form1()
            {
                InitializeComponent();
            }
    
            public void GoToNext()
            {
                MessageBox.Show("Play the next song");
            }
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.ObjectForScripting = new ScriptManager(this);
                webBrowser1.Navigate("http://localhost/index.html");
            }
        }
    }
