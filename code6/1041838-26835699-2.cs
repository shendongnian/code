    using System.Windows.Forms;
    
    namespace MyApplication
    {
        class MyTextBox : TextBox
        {
            protected override void OnKeyPress(KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
                {
                    e.Handled = true;
                }
    
                // only allow one decimal point
                if ((e.KeyChar == ',') && Text.IndexOf(',') > -1)
                {
                    e.Handled = true;
                }
                base.OnKeyPress(e);
            }
        }
    }
