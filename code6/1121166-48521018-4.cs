         public class MyCustomNumericBox : System.Windows.Forms.NumericUpDown
        {
            public MyCustomNumericBox()
            {
               Controls.Remove(Controls[0]);
            }
        }
    Full code to fit your request: 
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using System.Windows.Forms;
    namespace yournamespace
    {
        class NumericBx: NumericUpDown
        {
            public NumericBx()
            {
                var ctr = Controls[0];
                this.Controls[0].Visible = false;
                this.Controls[0].Enabled = false;
                this.Controls.Remove(ctr);
                // I have tried to rewrite sizes to hide unused area...but visual studio fails to 
                //show num control. That is why this part is commented 
                //Controls[0].Size = new Size(0, ClientSize.Height);
                //Controls[1].Size = new Size(ClientSize.Width, ClientSize.Height);
            }
        }
    }
