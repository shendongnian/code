    private void buttonCommonHandler_Click(object sender, EventArgs e)
    {
         Button b = sender as Button;
         CommonMethod(b.Tag.ToString());
    }
    private void CommonMethod(string sourceUrl)
    {
       // Execute the common code here....
    }
