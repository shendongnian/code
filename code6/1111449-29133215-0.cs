    using System;
    using System.Net;
    using System.Text;
    class AttachFile
    {
        static void Main ()
        {
            Uri uri = new Uri("https://app.asana.com/api/1.0/tasks/<TASK_ID>/attachments");
            string filePath = @"<FILE_PATH>";
            WebClient client = new WebClient();
            string authInfo = "<API_KEY>" + ":";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            client.Headers["Authorization"] = "Basic " + authInfo;
            client.UploadFile(uri, filePath); 
        }
    }
