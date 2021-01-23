    public static OperationResult CreateTfsGitRepository(string projectName, string repositoryName, string collectionName)
    {
        var tfsInstance = ConfigurationManager.AppSettings["TFSInstance"];
        using (var client = new WebClient())
        {
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.UseDefaultCredentials = true;
            var tfsNewRepository = new TfsRepository();
            tfsNewRepository.name = repositoryName;
            tfsNewRepository.project.id = TfsHelper.GetTfsProjectGuid(projectName, collectionName).id;
            var tfsUri = new Uri(tfsInstance + collectionName + "/_apis/git/repositories/?api-version=1.0");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            var jsonValues = jss.Serialize(tfsNewRepository);
            try
            {
                var response = client.UploadString(tfsUri, "POST", jsonValues);
            }
            catch (WebException ex)
            {
                //Handle WebExceptions here.  409 is the error code for a repository with the same name already exists within the specified project
            }
            return new OperationResult { ReturnValue = 0, Message = "Repository created successfully." };
        }
    }
