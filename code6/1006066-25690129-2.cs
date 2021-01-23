As requested, here is how to read a text file line by line and use the data within as the custom source for your AutoComplete
    string line = "";
    AutoCompleteStringCollection items = new AutoCompleteStringCollection();
    // Read the file and display it line by line.
    System.IO.StreamReader file = new System.IO.StreamReader("YOURFILE.txt");
    while((line = file.ReadLine()) != null)
    {
        if(!String.IsNullOrEmpty(line))
        {
            items.Add(line);
        }
    }
    file.Close();
