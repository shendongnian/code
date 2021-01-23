       // not here
       /****Refer to class constructor****/
       // ADUser userAttributes = new ADUser("", "", "", "", "", "", "");
        ...
             foreach (SearchResult iResult in searchresult)
             {
                 // but here.
                 ADUser userAttributes = new ADUser("", "", "", "", "", "", "");
                 foreach (string PropertyName in iResult.Properties.PropertyNames)
                 {
     
