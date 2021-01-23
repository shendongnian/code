    public class MyForm : Form 
    {
        bool _allowClose = false;
        void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4) _allowClose = true;
        }
        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_allowClose && e.CloseReason == CloseReason.UserClosing) e.Cancel = true;
        }
    }
