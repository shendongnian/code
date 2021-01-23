    var index = Int32.Parse(priority_add_textbox.Text);
    if (!rr_dict.ContainsKey(index))
    {
        rr_dict[index] = new List<process>();
    }
    ...
