        using Microsoft.Xrm.Sdk.Client;
        using Microsoft.Xrm.Sdk.Query;
        using Microsoft.Xrm.Sdk;
            
        //This is your Organization Service which you can find from the actual CRM UI. go to Settings>Customizations>Developer Resources.
        Uri organizationUri = new Uri("http://crmservername/organizationname/XRMServices/2011/Organization.svc"); 
        Uri homeRealmUri = null;
        ClientCredentials credentials = new ClientCredentials();
        //Instantiate your network credential that will access the CRM Server
        credentials.Windows.ClientCredential = new System.Net.NetworkCredential("username", "password", "domain");
                                
        OrganizationServiceProxy orgProxy = new OrganizationServiceProxy(organizationUri, homeRealmUri, credentials, null);
        //Instantiate IOrganizationService so you can call the CRM service methods.
         IOrganizationService _service = (IOrganizationService)orgProxy
    
    //from this you can now perform CRUD to your CRM. 
    //I'm just going to provide some example on how to query your entities in CRM like so:
    
        QueryExpression query = new QueryExpression() { };
                        
        query.EntityName = "country";
        query.ColumnSet = new ColumnSet("name", "2digitiso", "3digitiso");
                       
        EntityCollection retrieved = _service.RetrieveMultiple(query);
                        
        foreach (var item in retrieved.Entities)
        {
             MessageBox.Show(item["name"].ToString() + " " + item["2digitiso"].ToString() + " " + item["3digitiso"].ToString());
        }
