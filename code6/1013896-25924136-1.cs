    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    Query query = new Query(
         workItemStore, 
         "select * from issue where System.TeamProject = @project",
         new Dictionary<string, string>() { { "project", project.Name } }
    );
    var workItemCollection = query.RunQuery();
    foreach(Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItem workItem in workItemCollection) 
    {
       /*Get work item properties you are interested in*/
       foreach(Microsoft.TeamFoundation.WorkItemTracking.Client.Field field in workItem.Fields)
       {
          /*Get field value*/
          info += String.Format("Field name: {0} Value: {1}\n", field.Name, field.Value);
       }
    }
