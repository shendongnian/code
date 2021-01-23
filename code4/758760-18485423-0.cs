     private bool SaveDocument()
     {
            bool saved = false;
            try
            {
                Save();
                saved = true;
            }
            catch (Exception ex)
            {
               string errorTitle = Resources.SaveErrorCaption;
               string errorText = Resources.SaveErrorText;
               Exception initialEx = ex;
                while (ex.InnerException != null)
                {
                    if (ex.InnerException is SqlException)
                    {
                        int errorNo = ((SqlException)ex.InnerException).Number;
                        if (errorNo == 2627)
                        {
                            errorTitle = Resources.DuplicateEntryErrorTitle;
                            errorText = Resources.DuplicateEntryErrorMessage;
                        }
                    }
                    ex = ex.InnerException;
                }
                MsgBox.Show(errorTitle, errorText,
                    string.Format("{0}{1}StackTrace:{1}{2}", initialEx.Message, Environment.NewLine, initialEx.StackTrace),
                    MsgBoxButtons.OK, MsgBoxImage.Error);
                saved = false;
            }
 
            return saved;
    }
