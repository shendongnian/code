    public void btnClear_Click(object sender, EventArgs e)
    {
        if (isNew)
        {
            num1 = 0;
            c = "";
            // text box should already be empty
        }
        else
        {
            isNew = true;
            txtBox.Clear();
        }
    }
