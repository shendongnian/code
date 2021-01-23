    private void filterSelection(String[] location)
    {
        foreach (var checkBox in checkBoxArray)
        {
            var willCheck = CheckState.Unchecked;
            foreach (string match in location)
            {
                if (checkBox.Text.Contains(match))
                {
                    willCheck = CheckState.Checked;
                    break;
                }
            }
            checkBox.State = willCheck;
        }
    }
