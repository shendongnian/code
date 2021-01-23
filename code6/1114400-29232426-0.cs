    Dictionary<string, uint> dictionary = new Dictionary<string, uint>();
    dictionary.Add("1", 1);
    dictionary.Add("2", 2);
    dictionary.Add("3", 3);
    listData.DisplayMember = "Key";
    listData.ValueMember = "Value";
    var bs = new BindingSource();
    bs.DataSource = dictionary;
    listData.DataSource = bs;  // as last step
