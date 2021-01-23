    foreach (IValidator v in Page.GetValidators("t1"))
    {
        if (!v.IsValid)
        {
            cvt1.IsValid = false;
            return;
        }
    }
    cvt1.IsValid = true;
