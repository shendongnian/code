    foreach (var control in Page.Form.Controls)
    {
        if (control is HtmlInputControl)
        {
            var htmlInputControl = control as HtmlInputControl;
            string controlName = htmlInputControl.Name;
            string controlId = htmlInputControl.ID;
        }
    }
