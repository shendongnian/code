    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Compute.v1;
    using Google.Apis.Services;
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;
    
    using Data = Google.Apis.Compute.v1.Data;
    
    namespace ComputeSample
    {
        public class ComputeExample
        {
            public static void Main(string[] args)
            {
                ComputeService computeService = new ComputeService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = GetCredential(),
                    ApplicationName = "Google-ComputeSample/0.1",
                });
    
                // Project ID for this request.
                string project = "my-project";  // TODO: Update placeholder value.
    
                // The name of the zone for this request.
                string zone = "my-zone";  // TODO: Update placeholder value.
    
                // TODO: Assign values to desired properties of `requestBody`:
                Data.Instance requestBody = new Data.Instance();
    
                InstancesResource.InsertRequest request = computeService.Instances.Insert(requestBody, project, zone);
    
                // To execute asynchronously in an async method, replace `request.Execute()` as shown:
                Data.Operation response = request.Execute();
                // Data.Operation response = await request.ExecuteAsync();
    
                // TODO: Change code below to process the `response` object:
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
    
            public static GoogleCredential GetCredential()
            {
                GoogleCredential credential = Task.Run(() => GoogleCredential.GetApplicationDefaultAsync()).Result;
                if (credential.IsCreateScopedRequired)
                {
                    credential = credential.CreateScoped("https://www.googleapis.com/auth/cloud-platform");
                }
               return credential;
            }
        }
    }
