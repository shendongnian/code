    using CMS.OnlineForms;
    using CMS.DataEngine;
    using CMS.SiteProvider;
    using CMS.Helpers;
     
    ...
     
    // Gets the form info object for the 'ContactUs' form
    BizFormInfo formObject = BizFormInfoProvider.GetBizFormInfo("ContactUs", SiteContext.CurrentSiteID);
     
    // Gets the class name of the 'ContactUs' form
    DataClassInfo formClass = DataClassInfoProvider.GetDataClassInfo(formObject.FormClassID);
    string className = formClass.ClassName;
     
    // Loads the form's data
    ObjectQuery<BizFormItem> data = BizFormItemProvider.GetItems(className);
     
    // Checks whether the form contains any records
    if (!DataHelper.DataSourceIsEmpty(data))
    {
        // Loops through the form's data records
        foreach (BizFormItem item in data)
        {
            string firstNameFieldValue = item.GetStringValue("FirstName", "");
            string lastNameFieldValue = item.GetStringValue("LastName", "");
     
            // Perform any required logic with the form field values
     
            // Variable representing a custom value that you want to save into the form data
            object customFieldValue;
     
            // Programatically assigns and saves a value for the form record's 'CustomField' field
            item.SetValue("CustomField", customFieldValue);
            item.SubmitChanges(false);
        }
    }
