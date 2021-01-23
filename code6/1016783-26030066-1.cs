    private void button2_Click(object sender, EventArgs e)
    {
        try
        {
            int y = 2;
            int n = 0;
            int x = y / n;
        }
        catch (Exception ex)
        {
            CLASS.msgBox m = new CLASS.msgBox();
            m.ShowException(ex); // this is the method Required
        }
    }
