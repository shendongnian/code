    var selectedControls = div.Controls.OfType(CheckBoxList).Where(item => item.Selected);
    foreach(CheckBoxList item in selectedControls)
    {
        ...
    }
