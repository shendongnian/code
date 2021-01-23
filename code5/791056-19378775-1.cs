     using (SPSite oSPsite = new SPSite("http://SampletestSite.com/Trial"))
            {
                oSPsite.AllowUnsafeUpdates = true;
                using (SPWeb oSPWeb = oSPsite.OpenWeb())
                {
                    oSPWeb.AllowUnsafeUpdates = true;
                    SPList list = oSPWeb.Lists["Sample"];
                   StringCollection strViewFields = new StringCollection();
                        strViewFields.Add("Title");
                        strViewFields.Add("FirstName");
                        strViewFields.Add("LastName");
                // create a standard view with the set of fields defined in the collection
                   list.Views.Add("SampleTest", strViewFields, String.Empty,
                            100, true, false, SPViewCollection.SPViewType.Html, false);
                    
                   list.Update();
 
             oSPWeb.AllowUnsafeUpdates = false;
        }
 
    oSPsite.AllowUnsafeUpdates = false;
     }
