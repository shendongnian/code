    try
    {
        string[] names = new string[2];
        string g = names[2];
    }
    catch(Exception error) 
    {
        MessageBox.Show(error.Message);
    }
    // Index was outside the bounds of the array.
