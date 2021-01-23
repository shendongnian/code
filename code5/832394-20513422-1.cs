    if (!String.IsNullOrEmpty(modify))
    { 
        string modifications = "";
        foreach(string item in tcomboBox1.Items) 
        {
            bool contains = Regex.IsMatch(modify, item);
            if (contains)
            {
                string theItem = "$" + item + "$";
                modifications += modify.Replace(item,theItem) + Environment.NewLine;
            }
        }
        ttextBox1.Text = modifications;
        modify = "";
    }
