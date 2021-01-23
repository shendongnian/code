        internal static void DeleteDLXPolicyOnVhost()
        {
            const string policyURL = "http://localhost:15672/api/policies/vhost123/DLX";
            using (var client = new HttpClient())
            {
                var byteArray = Encoding.ASCII.GetBytes("username123:password123");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                var response = client.DeleteAsync(policyURL).Result;
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NoContent:
                        Console.WriteLine("Old DLX policy successfully deleted");
                        break;
                    case HttpStatusCode.NotFound:
                        Console.WriteLine("DLX policy was not found");
                        break;
                    default:
                    {
                        var content = response.Content;
                        throw new Exception(string.Format("Unhandled API response code of {0}, content: {1}", response.StatusCode, content));
                    }
                }
            }
        }
