    // the current input control
    Control focusedCtl = null;
    // variables to keep track of the cursor in the dgv cells
    int curSelStart = 0;
    TextBox curTB = null;
    // this is the common Enter event for all our input controls
    // we store which was entered/focused last
    private void control_Enter(object sender, EventArgs e)
    {
        focusedCtl = sender as Control;
    }
    // this is the common Click event for all buttons in your keypad
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
                if (curTB == null) curSelStart = -1; 
                else curSelStart = curTB.SelectionStart;
                if (input == "C") cell.Value = cell.Value == null ? 
                                  "" : TrimLast( cell.Value.ToString());
                else
                {
                    string cs = cell.Value == null ? "" : cell.Value.ToString();
                    if (curSelStart >= 0 && curSelStart < cs.Length) 
                         cell.Value = cs.Insert(curSelStart, input);
                    else cell.Value = cs + input;
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
    // we need a reference to the Textbox that is used for editing
    private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
        if (dataGridView1.CurrentCell.EditType == typeof(DataGridViewTextBoxEditingControl))
        {
            dataGridView1.BeginEdit(false);
            curTB = (TextBox)dataGridView1.EditingControl;
            if (curTB == null) return; 
            else curSelStart = curTB.SelectionStart;
            dataGridView1.BeginEdit(true);
        }
    }
