    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public class MyPanel : Panel
        {
    
            public bool Validate()
            {
                //What to write in here ?
                return true;
            }
    
            public bool ValidateChildren()
            {
                foreach (Control c in this.Controls)
                {
                    //What to write in here ?
                }
                return true;
            }
    
            public void Save()
            {
                if (Validate() && ValidateChildren())
                {
                    //Do something
                }
            }
    
            private void Save_Click(object sender, System.EventArgs e)
            {
                Save();
            }
            //something else
        }
    }
