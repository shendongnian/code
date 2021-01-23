    public string GetConcatenation(CheckBoxList list)
    {
        string value= ""; 
        for (int i = 0; i < list.Items.Count; i++)
        {
            if (list.Items[i].Selected)
            {
                if (value== "")
                    value= list.Items[i].Text;
                else
                    value+= "," + list.Items[i].Text;
            }
        }
        return value;
    }
