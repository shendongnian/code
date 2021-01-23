     static async Task RunAsync()
      {
          HttpClient client = new HttpClient();
          client.BaseAddress = new Uri(URL);
          
    	  var tasks = new List<Task<tsResponse>>();
    	  
          foreach (var workbk in (workbooksforuserresultingMessage.Items[1] as workbookListType).workbook)
          {
              if (workbk.project.name == "Ascend")
              {
    
                      tsResponse viewresultingMessage = null;
                      //Get View Data 
    
                      HttpRequestMessage viewrequestMessage = new HttpRequestMessage(HttpMethod.Get, "sites/" + ((siteresultingMessage.Items[0] as siteType).id.ToString()) + "/workbooks/" + workbk.id + "/views");
    
                      // Add our custom headers
                      viewrequestMessage.Headers.Add("X-Tableau-Auth", (resultingMessage.Items[0] as credentialsType).token.ToString());
    				
    				 tasks.Add(GetViewString(viewrequestMessage);
              }
          }
         	  
          foreach (var workbk in (workbooksforuserresultingMessage.Items[1] as workbookListType).workbook)
          {
    
              if (workbk.project.name == "Ascend")
              {
    
                  foreach (var vu in workbk.views)
                  {
                      tsResponse viewImageresultingMessage = null;
                      //Get View Data 
    
                      HttpRequestMessage viewImagerequestMessage = new HttpRequestMessage(HttpMethod.Get, "sites/" + ((siteresultingMessage.Items[0] as siteType).id.ToString()) + "/workbooks/" + workbk.id + "/views/" + vu.id + "/previewImage");
    
                      // Add our custom headers
                      viewImagerequestMessage.Headers.Add("X-Tableau-Auth", (resultingMessage.Items[0] as credentialsType).token.ToString());
    
    				  tasks.Add(GetViewImage(viewImagerequestMessage);
                  }
              }
          }
    	  
    	  // wait for all the tasks to complete (non blocking)
    	  await Task.WhenAll(tasks);
    }
