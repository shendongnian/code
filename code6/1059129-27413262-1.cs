    List (int) nValues = new List(int)()
    foreach item in DropDownList.Items 
    {
        nValues.Add(Int32.Parse(item.Split("--")[1].Trim()))
    }
    // Do something with the values
