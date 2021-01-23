    //Global variables
    string _param1 = string.Empty,
           _param2 = string.Empty;
    //On click method for search btn
    protected void OnSearch(object sender, EventArgs e)
    {
        gv.DataBind();
        
        someHiddenField = SelectCountMethod(param1, param2); 
    }
    protected void OnSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            try
            {
                e.InputParameters["Param1"] = param1;
                _param1 = param1                
                e.InputParameters["Param2"] = param2; 
                _param2 = param2;      
            }
            catch (Exception ex)
            {
                cvServerError.IsValid = false;
                cvServerError.ErrorMessage = ex.Message;
            }
        }
