    double parts;
    try
    { 
        parts = double.Parse(partsTextBox.Text);
    }
    catch (FormatException fe)
    {
        MessageBox.Show("Quantity of parts not informed");
    }
