    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class Test
    {
        static void Main()
        {
            var rtb = new RichTextBox {
                Text = "Test",
                ReadOnly = true
            };
            rtb.Select(1, 3);
            rtb.SelectionColor = Color.Red;
            rtb.DeselectAll();
            var form = new Form { Controls = { rtb } };
            Application.Run(form);
        }
    }
