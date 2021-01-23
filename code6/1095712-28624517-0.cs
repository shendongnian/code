    [DllImport("user32.dll")]
    static extern IntPtr SetFocus(IntPtr hWnd);
    private void button1_Click(object sender, EventArgs e)
    {
        this.BeginInvoke(new MethodInvoker(() =>
        {
            SetFocus(IntPtr.Zero);//Remove the focus
        }));
        MessageBox.Show("I should not have a button on focus",
                   "Test",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button3);
    }
