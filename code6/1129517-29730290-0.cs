    int iTextBox1;
    DateTime dDate;
    
    if (!Integer.TryParse(textbox1.Text, out iTextBox) || iTextBox > 6)
    { 
        MessageBox.Show "Error in textbox1";
    }
    
    if (!Date.TryParse(textbox2.Text, out dDate))
    {
        MessageBox.Show "Error in textbox2";
    }
