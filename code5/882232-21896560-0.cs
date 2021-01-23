    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net.Http;
    
    namespace DownloadSample
    {
        class Program
        {
    
            static async void RunClient(string address)
            {
                HttpClient client = new HttpClient();
    
                // Send asynchronous request
                HttpResponseMessage response = await client.GetAsync(address);
    
                // Check that response was successful or throw exception
                response.EnsureSuccessStatusCode();
    
                // Read response asynchronously and save asynchronously to file
                using (FileStream fileStream = new FileStream("c:\\temp\\logo.jpg", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await response.Content.CopyToAsync(fileStream);
                }
            }
    
            static void Main(string[] args)
            {
                string microsoft_logo = "http://c.s-microsoft.com/en-au/CMSImages/mslogo.png?version=856673f8-e6be-0476-6669-d5bf2300391d";
                RunClient(microsoft_logo); //"http://some.domain.com/resource/file.jpg");
    
                Console.WriteLine("Check download folder");
                Console.ReadLine();
            }
        }
    }
