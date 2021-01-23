    var results = collection.Find(Query.EQ("Name", Textbox1.Text));
    if (results.Count() == 0)
    {
        Console.WriteLine("no matches");
        // or MessageBox.Show(...)
    }
