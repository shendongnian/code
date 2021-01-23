            const string ErrorCssClass = "error";
            Validate();
            if (IsPostBack && !IsValid)
            {
                var content = Form.FindControl("MainContent") as ContentPlaceHolder;
                foreach (BaseValidator validator in Validators)
                {
                    if (validator.IsValid)
                        continue;
                    var controlToValidate = content.FindControl(validator.ControlToValidate) as WebControl;
                    if (controlToValidate != null && !controlToValidate.CssClass.Contains(ErrorCssClass))
                        controlToValidate.CssClass += " " + ErrorCssClass;
                }
            }
