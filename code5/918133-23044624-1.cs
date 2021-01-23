    bool first = true;
    //loop through each of the input records
    foreach (string record in input)
    {
        //split the input records based on the pipe character
        fields = record.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        //loop through each of the fields
        foreach (string field in fields)
        {
            if (first) //split the first field based on the first space in field
            {
                current = new List<string>();
                index = field.IndexOf(" ");
                current.Add(field.Substring(0, index).Trim());
                current.Add(field.Substring(index + 1).Trim());
                first = false;
            }
            else  //split subsequent records based on second space if it exists
            {
                 index = field.IndexOf(" ", 3);
                 if (index == -1)
                 {
                     current.Add("|" + field);
                 }
                 else
                 {
                     current.Add("|" + field.Substring(0, index).Trim());
                     current.Add(field.Substring(index + 1).Trim());
                 }
            }
        }
        //control break processing
        first = true;
        output.Add(current.ToArray());
    }
