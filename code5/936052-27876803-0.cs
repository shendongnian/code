                            ID = string.Concat(TheControl.ID, "_customFieldValidator"),
                            EnableClientScript = false,
                            Display = ValidatorDisplay.Dynamic,
                            ErrorMessage = "Required",
                            CssClass = "error",
                            ControlId = TheControl.ID
                        };
                        customValidator.ServerValidate += customValidator_ServerValidate;
