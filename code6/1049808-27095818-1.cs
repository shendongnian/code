    .....
    string[] words = message.Split(' ');
    foreach (string word in words)
    {
        if (word.StartsWith("#"))
        {
            // Search if the table contains a row with the current word in the Hashtag column
            DataRow[] selection = hashtags.Select("Hashtag = '" + word + "'");
            if(selection.Length > 0)
            {
                // We have a row with that term. Increment the counter
                // Notice that selection is an array of DataRows (albeit with just one element)
                // so we need to select the first row [0], second column [1] for the value to update
                int count = Convert.ToInt32(selection[0][1]) + 1;
                selection[0][1] = count;
            }
            else
            {
                row = hashtags.NewRow();
                row["Hashtag"] = word;
                row["Count"] = "1";
                hashtags.Rows.Add(row);
            }
        }
    }
