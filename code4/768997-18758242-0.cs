    public void CheckField(string text, string textBoxName)
    {
       if(text == null || text == string.Empty)
       {
            MessageBox.Show(this, textBoxName + " is empty, please fill it",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
    }
