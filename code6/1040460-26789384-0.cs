    public bool CheckForDuplicates()
    {
        //Collect all your TextBox objects in a new list...
        List<TextBox> textBoxes = new List<TextBox>
        {
            textBox1, textBox2, textBox3
        };
        //Use LINQ to count duplicates in the list...
        int dupes = textBoxes.GroupBy(x => x.Text)
                             .Where(g => g.Count() > 1)
                             .Count();
        if (dupes > 0)
            return true; //at least 1 duplicate entry
        else
            return false; //no duplicate entries
    }
