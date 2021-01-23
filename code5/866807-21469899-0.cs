    foreach (Control ctrl in this.Controls)
    {
        if (ctrl is HiddenField)
        {
            if (!string.IsNullOrEmpty((ctrl as HiddenField).Value))
            {
                // do something
            }
        }
    }
