    delegate void Validate(string text);
    protected void nameSearch_Click(object sender, EventArgs e)
    {
        Validate validate;
        if (offRadio.Checked)
            validate = PersonNameValidator;
        else if (comRadio.Checked)
            validate = CompanyNameValidator;
        else
            validate = GeneralValidator;
        validate(nameBox.Text);
        ... More code, blah blah ...
    }
    private void PersonNameValidator(string text)
    {
        // Validate person name
    }
    private void CompanyNameValidator(string text)
    {
        // Validate company name
    }
    private void GeneralValidator(string text)
    {
        // Validate general properties
    }
