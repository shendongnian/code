    public string[] selected()
    {
        string strTemp = "";
        for (int i = 0; i < chbindustry.Items.Count - 1; i++)
        {
            if (chbindustry.Items[i].Selected)
            {
                strTemp += chbindustry.Items[i].Text.ToString() + ",";
            }
        }
        string[] selecteditems = strTemp.Split(','); 
        return selecteditems;
    }
