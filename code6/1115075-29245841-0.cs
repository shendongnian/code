    private string ReadName(out bool success)       
    {
        string name = "";
        success = Regex.IsMatch(Nametxt.Text, "^[a-zA-Z]+$");
        if (!success)
            MessageBox.Show("The entered name is not valid!");
        else
            name = Nametxt.Text;
        return name;        
    }
