    private bool flag = false;
    private void button1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Return)
        {
            flag = true;
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (flag)
        {
            flag = false;
            return;
        }
        //else do original task
    }
