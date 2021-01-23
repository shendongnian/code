    delegate DialogResult MyInvoke(Form Parent, string Text, string Caption, MessageBoxButtons Buttons, MessageBoxIcon Icon, MessageBoxDefaultButton DefaultButton);
    public static DialogResult ShowMessage(Form Parent, string Text, string Caption, MessageBoxButtons Buttons, MessageBoxIcon Icon, MessageBoxDefaultButton DefaultButton)
    {
        if (Parent.InvokeRequired){
            return (DialogResult)Parent.Invoke(new MyInvoke(ShowMessage), Parent, Text, Caption, Buttons, Icon, DefaultButton);
        }
        return MessageBox.Show(Text, Caption, Buttons, Icon, DefaultButton);
    }
