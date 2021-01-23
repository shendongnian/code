    var allIndexes = new List<int>
    {
        DropDownList_l1_1.SelectedIndex,
        DropDownList_l1_2.SelectedIndex,
        DropDownList_l1_3.SelectedIndex,
        DropDownList_l1_4.SelectedIndex,
        DropDownList_l1_5.SelectedIndex
    };
    var noSelectedIndexIsTheSame = allIndexes.Where(x => x != 0)
                                             .GroupBy(x => x)
                                             .All(x => x.Count() == 1);
    if (noSelectedIndexIsTheSame)
    {
       // no selected values are the same, so do something
       ...
    }
