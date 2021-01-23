    private void ShowTextboxes(bool isRemoveLast)
    {
        if (textBoxList == null || name == null)
            return;
        //if remove the last element - remove it
        if (isRemoveLast)
            textBoxList.RemoveAt(textBoxList.Count - 1);
        //add each text box to the container
        foreach (TextBox textBox in textBoxList)
        {
            // Populate value
            textBox.Text = Request.Form[textBox.Name]
            //RequiredFieldValidator validator = new RequiredFieldValidator();
            //validator.ErrorMessage = "*required";
            //validator.ControlToValidate = textBox.ID;
            container.Controls.Add(textBox);
            //container.Controls.Add(validator);
            container.Controls.Add(new LiteralControl("<br/>"));
        }
    }
