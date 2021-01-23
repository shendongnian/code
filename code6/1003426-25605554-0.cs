    List<CheckBox> checkBoxesList = new List<CheckBox>();
    foreach (Control ctrl in FormName.Controls)
    {
        if (ctrl.GetType() == typeof(CheckBox))
        {
            checkBoxesList.Add(ctrl as CheckBox);
        }
    }
