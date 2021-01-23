    // error if string is null or empty
    // if (!string.IsNullOrEmpty(tb.Text))
    if (string.IsNullOrEmpty(tb.Text))
    {
       error.SetError(tb, "*");
       e.Cancel = true;
    }
    else
    {
       error.SetError(tb, "");
    }
