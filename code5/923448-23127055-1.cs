      #region stop point
            string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
            if (textboxValues != null)
            {
                for (Int32 i = 0; i < textboxValues.Length; i++)
                {
                    if (textboxValues.Length == 1)
                    {
                        model.OptionalRoot = textboxValues[0].ToString();
                    }
                    else if (textboxValues.Length == 2)
                    {
                        model.OptionalRoot = textboxValues[0].ToString();
                        model.OptionalRoot2 = textboxValues[1].ToString();
                    }
                    else if (textboxValues.Length == 3)
                    {
                        model.OptionalRoot = textboxValues[0].ToString();
                        model.OptionalRoot2 = textboxValues[1].ToString();
                        model.OptionalRoot3 = textboxValues[2].ToString();
                    }
                    else
                    {
                        model.OptionalRoot = "";
                        model.OptionalRoot2 = "";
                        model.OptionalRoot3 = "";
                    }
                }
            }
            #endregion
