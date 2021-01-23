    public string GetConcatenation(ListItemCollection list)
    {
        string value= ""; 
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].Selected)
            {
                if (value== "")
                    value= list[i].Text;
                else
                    value+= "," + list[i].Text;
            }
        }
        return value;
    }
