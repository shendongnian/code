    public void CheckACheckBox(Checkbox ck)
    {
        foreach (Control ckb in this.Controls)
        {
           if ((ckb is CheckBox) && (ckb == ck))
              ck.Checked = true;
           else
              ck.Checked = false;
        }
    }
