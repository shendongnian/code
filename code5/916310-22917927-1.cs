    private void filterSelection(String[] locations)
    {
        foreach (var checkBox in checkBoxArray)
        {
            var willCheck = CheckState.Unchecked;
            foreach (string location in locations)
            {
                if (checkBox.Text.Contains(location))
                {
                    willCheck = CheckState.Checked;
                    break;
                }
            }
            checkBox.State = willCheck;
        }
    }
