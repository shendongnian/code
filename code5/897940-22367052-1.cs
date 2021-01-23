    public bool AreAllCheckboxesChecked
    {
        return (ChkBx1.Checked && ChkBx2.Checked && ChkBx3.Checked);
    }
    public bool AreAllCheckboxesUnchecked()
    {
        return (!ChkBx1.Checked && !ChkBx2.Checked && !ChkBx3.Checked);
    }
