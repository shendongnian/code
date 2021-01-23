    private IList<string> GetErrorsForControls(ControlCollection controls)
    {
        var errors = new List<string>();
        foreach (var control in controls)
        {
            if (control is TextBox)
                if (string.IsNullOrWhitespace((control as TextBox).Text))
                    errors.Add(string.Format("{0} is empty.", (control as TextBox).Name));
            errors = errors.Concat(GetErrorsForControls(control.Controls));
        }
        return errors;
    }
