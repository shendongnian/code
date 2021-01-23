    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    
    namespace DisposeSample
    {
        public partial class Form1 : Form
        {
            
            // Default Constructor
            public Form1()
            {
                InitializeComponent();
            }
    
    
            // Form Load Event Handler
            private void Form1_Load(object sender, EventArgs e)
            {
                timer1.Interval = 500;
                timer1.Enabled = true;
            }
    
    
    
            /*
                Timer1 Tick Event Handler
                (This Timer Control was dragged and dropped onto the form in the designer).
            */
            private void timer1_Tick(object sender, EventArgs e)
            {
                // Create a new App Domain object
                AppDomain newDomain = AppDomain.CreateDomain("Other Guy's DLL");
    
                // Get the Assembly Name of the Create New Domain Instance Class
                string aName = typeof(CreateNewDomainInstanceClass).Assembly.FullName;
    
                // Get the Full Name of the Create New Domain Instance Class
                string tName = typeof(CreateNewDomainInstanceClass).FullName;
    
                // Create a new instance of the Create New Domain Instance Class in the new App Domain
                CreateNewDomainInstanceClass ndInstance = (CreateNewDomainInstanceClass)newDomain.CreateInstanceAndUnwrap(aName, tName);
                
                // Run the public method in the new instance
                ndInstance.RunOtherGuysCode();
    
                // Unload the new App Domain object
                AppDomain.Unload(newDomain);
    
                // Call an immediate Garbage Collection to ensure that all unused resources are removed from RAM
                GC.Collect();
            }
    
        }
    }
