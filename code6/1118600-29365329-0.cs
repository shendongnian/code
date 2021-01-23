    public void InsertItem()
        {
            Channel item = null;
            item = new Channel();
    
            TryUpdateModel(item);
    
            if (ModelState.IsValid)
            {                
                // Save changes
                _db.Channels.Add(item);
                _db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("###  EF ID OF Newly Created CHANNEL = " + item.ChannelId);
    
                // Create Folder for the Channel based on its ID
                string pathToCreate = "~/CRMImages/Channels/" + item.ChannelId;
                string myFileName = "";
                if (!Directory.Exists(Server.MapPath(pathToCreate)))
                {
                    DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(pathToCreate));
                    var user = System.Security.Principal.WindowsIdentity.GetCurrent().User;
                    var userName = user.Translate(typeof(System.Security.Principal.NTAccount));
                    System.Security.AccessControl.DirectorySecurity sec = di.GetAccessControl();
                    sec.AddAccessRule(new System.Security.AccessControl.FileSystemAccessRule(userName,
                        System.Security.AccessControl.FileSystemRights.Modify,
                        System.Security.AccessControl.AccessControlType.Allow));
                    di.SetAccessControl(sec);
    
                    System.Diagnostics.Debug.WriteLine("CHannel FOLDER CREATED PATH : " + di.FullName);
                    myFileName = pathToCreate + "/pancardImg.png";
                    System.Diagnostics.Debug.WriteLine("PATH To Save PAN File & NAME : " + myFileName);
    
                    // PAN CARD IMAGE
                    FileUpload panInsertUpload = InsertChannelId.FindControl("panInsertUpload") as FileUpload;
                    if (panInsertUpload != null)
                    {
                        if (panInsertUpload.HasFile)
                        {
                            System.Diagnostics.Debug.WriteLine("EDIT UNIT PLAN FILE NAME =" + panInsertUpload.FileName);
                            myFileName = pathToCreate + "/pancardImg.png";
                            panInsertUpload.SaveAs(Server.MapPath(myFileName));
                            item.PanImageURL = myFileName;
                        }
                    }
    
                    TryValidateModel(item);
                    _db.SaveChanges();
                }
                Response.Redirect("Default");
            }
        }
