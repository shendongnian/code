    [DllImport("user32.dll")]
    static extern IntPtr SetFocus(IntPtr hWnd);
    private void button1_Click(object sender, EventArgs e)
    {
        //Post a message to the message queue.
        // On arrival remove the focus of any focused window. 
        //In our case it will be default button.
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
