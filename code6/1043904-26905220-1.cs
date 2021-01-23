    private void convertBasetoDrawn(List<TextBox> list, string numBase, string reference)
    {
        string baseNumber = numBase;
        string[] texts = new string[8] 
                     { "000", "500", "050", "005", "550", "505", "055", "555" };
        for (int t = 0; t < list.Count; t++)  list[t].Text = texts[t];
        list[0].ForeColor = Color.Red;
        list[7].ForeColor = Color.Red;
    }
