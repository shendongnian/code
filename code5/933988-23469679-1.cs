    using System;
        using System.Windows.Forms;
        using ProjB;
        
        namespace ProjA
        {
             ProjB.ClassB classb=new ProjB.ClassB();
            public FormA()
            {
                InitializeComponent();
                ....
               classb.bValue=....//set desired valued
            }
        
            private void FormA_Load(object sender, EventArgs e)
            {
               
                int va =classb.bValue;
            }
