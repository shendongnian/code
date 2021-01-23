    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    ...
    textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9+/*()%.-]"))
        {
            e.Handled = true; // Do not allow input
        }
    }
