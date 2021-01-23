    // the current input control
    Control focusedCtl = null;
    // this is the common Enter event for all our input controls
    // we store which was entered/focused last
    private void control_Enter(object sender, EventArgs e)
    {
        focusedCtl = sender as Control;
    }
    // this is the common Click event for all buttons in out keypad
    private void padButton_Click(object sender, EventArgs e)
    {
        // reference to the sender
        Button padKey = sender as Button;
        // one way to get the text to process, Tag would be another
        string input = padKey.Text;
        // we do a lot of checks and beep&leave on fail
        if (focusedCtl == null) { Console.Beep(); return ;}
        // try to decide which is the receiving control
        DataGridView dgv = focusedCtl as DataGridView;
        TextBox tb = focusedCtl as TextBox;
        if (dgv != null)
        {
            DataGridViewCell cell = dgv.CurrentCell;
            if (cell == null) { Console.Beep(); return; }
            else
            {
                if (input == "C") 
                  cell.Value = cell.Value == null ? "" : TrimLast( cell.Value.ToString());
                else
                {
                    if (cell.Value == null) cell.Value = input;
                    else cell.Value = cell.Value.ToString() + input;
                }
            }
        }
        else  if (tb != null)
        {
            if (input == "C") tb.Text = TrimLast(tb.Text);
            else
            {
                int sstart = tb.SelectionStart;
                tb.Text = tb.Text.Insert(sstart, input);
                tb.SelectionStart += input.Length;
            }
        }
        else Console.Beep();
    }
    string TrimLast(string s) { return s.Substring(0, Math.Max(0, s.Length - 1)); }
