    public void Button1_Click(object sender, EventArgs e)
    {
        try {
            // Do something interesting, like calling methods that throw (nested) exceptions
            // Maybe these methods do file I/O
        }
        // Though it's better to catch a more-specific exception or set of exceptions
        catch (IOException ex){ 
            MessageBox.Show(ex.ToString());
        }
    }
