     using (ClientContext context = TokenHelper.GetClientContextWithAccessToken(Request.QueryString["SPHostUrl"].ToString(), accessToken))
                    {
                        //Get Web and List object
                        Web web = context.Site.OpenWeb("test");
                        List list = web.Lists.GetByTitle("Documents");
                        //Open file
                        System.IO.FileStream stream = System.IO.File.OpenRead(txtFilePath.Text);
                        //Create new file creation info object        
                        FileCreationInformation fileCreation = new FileCreationInformation();
                        fileCreation.ContentStream = stream;
                        fileCreation.Overwrite = true;
                        fileCreation.Url = "test";
                        //Add File to documents library
                        File uploadedFile = list.RootFolder.Files.Add(fileCreation);
                        list.Update();
                        web.Update();
                        context.ExecuteQuery();
                    }
               
