    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Auto
    {
    
        public interface IAuto
        {
            string SendToOtherApp();
        }
    
        public class Auto : IAuto
        {
            public string tbox1;
            NAVForm frm1 = new NAVForm();
    
            public Auto()
            {
            }
    
            public string SendToOtherApp()
            {
                frm1.ShowDialog();
                tbox1 = frm1.UseThis(frm1.textBox1.Text);
                return tbox1;
            }
        }
    }
