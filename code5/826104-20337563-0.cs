    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    class Test
    {
        static void Main()
        {
            Form form = new Form();
            form.Load += Form1_Load;
            Application.Run(form);
        }
        
        private static void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["666bytes"] = "ME";
            MessageBox.Show(dic["should_give_error"]);
        }
    }
