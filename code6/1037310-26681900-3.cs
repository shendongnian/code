    private void UncheckAllCheckBoxes()
    {
        foreach (bool? cbIsChecked in yourCheckStates)
        {
            cb.IsChecked = false;
        }
    }
