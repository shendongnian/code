    if (reader.Name == "WindowsPort")
    {
        int i = -1;
        if (Int32.TryParse(reader.Value, out i))
        {
            numericUpDown1.Value = i;
        }
        else
        {
            //Unexpected Result; Value not a number
        }     
    }
