    var subNameList = new List<string>();
    foreach (var item in myCheckedListBox.Items)
    {
        foreach (string subName in (item.ToString().Split('+'))
        {
            subNameList.Add(subName);
        }
    }
