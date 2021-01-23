    protected void updateLabel(string value)
    {
        if(Session["numbers"]!=null)
            numbers = (ArrayList)Session["numbers"];
        numbers.Add(value);
        Session["numbers"] = numbers;
        
        foreach (string number in numbers)
        {
            text += number + ',';
        }
        //Remove the end ','
        lblOne.Text = text.Substring(0, text.Length - 1);
    }
