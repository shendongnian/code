    using Microsoft.TeamFoundation.WorkItemTracking.Proxy;
    var tpc = new TfsTeamProjectCollection(new Uri("<collection URL>"));
    var store = tpc.GetService<WorkItemStore>();
    var teamProject = store.Projects["<project name>"];
    var server = tpc.GetService<WorkItemServer>();
    FileAttachment attachment = new FileAttachment();
    attachment.LocalFile = stream; /*this is the stream object with attachment contents*/
    attachment.AreaNodeUri = teamProject.AreaRootNodes[0].Uri.ToString();
    attachment.FileNameGUID = Guid.NewGuid(); /*just random guid*/
    attachment.ProjectUri = teamProject.Uri.ToString();
    server.UploadFile(attachment); /*upload the file to TFS*/
    /*Time to attach the TFS file to the work item. We need to use Update() method directly*/
    const string c_UpdatePackage = 
                    @"<Package AttachmentUrl=""{7}/WorkItemTracking/v1.0/AttachFileHandler.ashx"" xmlns="""">
                       <UpdateWorkItem ObjectType=""WorkItem"" ClientCapabilities=""0"" WorkItemID = ""{0}"" Revision=""{1}"">
                         <InsertFile FieldName=""System.AttachedFiles"" OriginalName=""{2}"" FileName=""{3}"" CreationDate=""{4}"" LastWriteDate=""{4}"" FileSize=""{5}"" />
                           <Columns>
                             <Column Column=""System.ChangedBy"" Type=""String"">
                               <Value>{6}</Value>
                             </Column>
                           </Columns>
                           <ComputedColumns>
                             <ComputedColumn Column=""System.PersonId"" />
                             <ComputedColumn Column=""System.RevisedDate"" />
                             <ComputedColumn Column=""System.ChangedDate"" />
                             <ComputedColumn Column=""System.AuthorizedDate"" />
                             <ComputedColumn Column=""System.Watermark"" />
                           </ComputedColumns>
                        </UpdateWorkItem>
                       </Package>";
    XmlDocument updatePackage = new XmlDocument();
    updatePackage.LoadXml(string.Format(c_UpdatePackage, 
                    1 /*work item ID*/, 
                    2 /*work item latest revision*/, 
                    "<file name you want, it will show up in the work item attachment tab>", 
                    attachment.FileNameGUID,
                    DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"),
                    fileContent.Length, 
                    "<display name of the TFS user making the change, e.g. John Smith>",
                    "<collection url, e.g. http://localhost:8080/tfs/defaultcollection>"));
                XmlElement outputPackage; /*this can be ignored*/
                string dbStamp; /*this can be ignored*/
                IMetadataRowSets metadata; /*this can be ignored*/
                server.Update(Guid.NewGuid().ToString(),
                    updatePackage.DocumentElement,
                    out outputPackage,
                    null,
                    out dbStamp,
                    out metadata);
