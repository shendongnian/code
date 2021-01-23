    void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (shouldNotHandle)
            return;
        // ...
        else if (Result1 == DialogResult.Cancel)
        {
            shouldNotHandle = true;
            checkBox1.Checked = true;
            shouldNotHandle = false;
        }
    }
