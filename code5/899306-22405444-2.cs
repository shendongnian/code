    try
    {
        if (editedCustomerRequest.OwnerID == null)
        {
            goto exitTry;
        }
        Hashtable xsltValues = new Hashtable();
        xsltValues.Add("fso:LicenseKeyRequest", request);
        string xsltTemplateFile = string.Format("{0}{1}", workflowProperties.WebUrl, _configItems[_lkrAdminReminderEmailTemplateUrl]);                
        Email email = new Email(xsltTemplateFile, xsltValues);
     }
     catch(){}
     exitTry:
