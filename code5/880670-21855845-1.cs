        protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxFileUploadEventArgs file)
        {
           if (!string.IsNullOrEmpty(file.ContextKeys))
           {
                var longLat = new     System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Dictionary<string,   string>>(file.ContextKeys);
               var longitude = longLat["longitude"];
               var latitude = longLat["latitude"];
           }
           //code to save file
       }
