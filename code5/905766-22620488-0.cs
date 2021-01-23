    public static void AddStatusMessage(string type, string message, System.Web.SessionState.HttpSessionState sessionState, List<string> successMessageList, List<string> errorMessageList)
    {
        if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(type)) 
        {
            return; 
        }
        if (type == "success")
        {
            if (successMessageList != null)
            {
                successMessageList.Add("SUCCESS: " + message);
            }
            if (sessionState != null)
            {
                sessionState["SuccessMessageList"] = successMessageList;
            }
        }
        else if (type == "error")
        {
            if (errorMessageList != null)
            {
                errorMessageList.Add(message);
            }
            if (sessionState != null)
            {
                sessionState["ErrorMessageList"] = errorMessageList;
            }
        }
    }
