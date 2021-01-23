    protected void btnPublish_Click(object sender, EventArgs e)
        {
            //copy the created file content to destination
             string sourcePath=string.Empty;
             string destiPath = "d://test//";
            if(!string.IsNullOrEmpty(hdnPublishPath.Value))
            { 
                sourcePath= hdnPublishPath.Value;
                if (!Directory.Exists(destiPath)) // check if folde exist
                {
                    Directory.CreateDirectory(destiPath); // create folder
                    //Directory.Delete(destiPath, true);  // delete folder
                }
    
                File.Copy(sourcePath, destiPath,true);
            }
        }
