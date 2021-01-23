        void customValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var customValidator = source as CustomValidatorWithValidatedControlAttributes;
            if (customValidator != null)
            {
                var checkBox = FindControl(customValidator.ControlId) as CheckBox;
                if (checkBox != null)
                {
                    args.IsValid = checkBox.Checked;
                }
            }
            args.IsValid = false;
        }
