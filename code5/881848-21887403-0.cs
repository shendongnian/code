    //leave only the digits
    for (int i = enteredPhone.Length - 1; i >= 0; i--)
    {
        if (!Char.IsDigit(enteredPhone[i]))
        {
           enterPhone = enteredPhone.Remove(i, 1);
        }
    }
