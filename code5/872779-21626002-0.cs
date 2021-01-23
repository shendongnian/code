    public string ConcatCheckboxlist(CheckBoxList chklist)
    {
        string sRet;
        if (chklist.Items[i].Selected)
        {
            if (sRet == "")
                sRet= chklist.Items[i].Text;
            else
                sRet+= "," + chklist.Items[i].Text;
        } 
        return sRet;
    }
