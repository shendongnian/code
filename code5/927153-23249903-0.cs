    protected bool SetCheckedStatus(object typeDesc)
    {
        var isChecked = false;
        var intValue = 0;
        if (typeDesc != null)
        {
            int.TryParse(typeDesc.ToString(), out intValue);
            if (intValue == 1) { isChecked = true; }
        }
        return isChecked;
    }
