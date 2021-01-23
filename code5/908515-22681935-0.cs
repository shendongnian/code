    RequiredFieldValidator rfv = new RequiredFieldValidator {
                        ID = "val" + txField.ColumnName,
                        ControlToValidate = "txt" + txField.ColumnName,
                        Display = ValidatorDisplay.Dynamic,
                        Text = "*",
                        CssClass = "validation-asterix"
                     };
    ContentPlaceHolderID.Controls.Add(rfv);
