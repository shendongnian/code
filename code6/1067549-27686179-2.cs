    public void GetValue()
    {
        n = Convert.ToInt16(txtInputFields.Text);
        values = new double[n];
    
        // textBoxes = new TextBox[n];
    
        for (int i = 0; i < n; i++)
        {
           values[i] = Convert.ToDouble(textBoxes[i].Text);
    
        }
    }
