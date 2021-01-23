    private async void Save_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        try
        {
            Controller.Busy = true;
    
                try
                {
                    await Task.Run(() => Controller.SaveItem());
                }
                catch (BdlDbException ex)
                {
                    if (ex.ExceptionSubType == DbExceptionSubTypes.UniqueViolation)
                    {
                        HandleUniqueViolation(ex);
                    }
                    else
                    {
                        string errorMessage = "";
                        errorMessage = ex.Message;
                        Utils.ShowMessageBox(t_MessageBox.Attention, errorMessage);
                    }
                }
    
                Controller.Busy = false;
        }
        catch (FieldException ex)
        {
            if (ex.FieldName == "FirstName")
            {
                TbFirstName.ValidationError = true;
                TbFirstName.ApplyErrorToolTip(ex.Message);
            }
        }
    }
