    public ActionResult DynamicWeb()
    {
    
                try
                {
    
    
                    string metabasePath = Convert.ToString(ConfigurationManager.AppSettings["metabasePath"]);
                    string frameworkVersion = Convert.ToString(ConfigurationManager.AppSettings["frameworkVersion"].ToString());
                    string physicalPath = Convert.ToString(ConfigurationManager.AppSettings["defaultFileLocation"].ToString());
                    string defaultAppPool = ConfigurationManager.AppSettings["defaultAppPool"].ToString();//Host Header Info
                    object[] hosts = new object[2];
                    string hostHeader = "Dynamic1"; //siteName.Replace("www.", string.Empty).Replace(".com",string.Empty);
                    hosts[0] = ":80:" + hostHeader + ".com";
                    hosts[1] = ":80:" + "www." + hostHeader + ".com";
    
                    //Gets unique site id for the new website
                    int siteId =GetUniqueSiteId(metabasePath);
    
                    //Extracts the directory entry
                    DirectoryEntry objDirEntry = new DirectoryEntry(metabasePath);
                    string className = objDirEntry.SchemaClassName;
                   
    
                    //creates new website by specifying site name and host header
                    DirectoryEntry newSite = objDirEntry.Children.Add(Convert.ToString(siteId), (className.Replace("Service", "Server")));
                    newSite.Properties["ServerComment"][0] = "Dynamic1";
                    newSite.Properties["ServerBindings"].Value = hosts;
                    newSite.Invoke("Put", "ServerAutoStart", 1);
                    newSite.Invoke("Put", "ServerSize", 1);
                    newSite.CommitChanges();
    
                    //Creates root directory by specifying the local path, default  document and permissions
                    DirectoryEntry newSiteVDir = newSite.Children.Add("Root", "IIsWebVirtualDir");
                    newSiteVDir.Properties["Path"][0] = physicalPath;
                    newSiteVDir.Properties["EnableDefaultDoc"][0] = true;
                    //newSiteVDir.Properties["DefaultDoc"].Value = "default.aspx";
                    newSiteVDir.Properties["AppIsolated"][0] = 2;
                    newSiteVDir.Properties["AccessRead"][0] = true;
                    newSiteVDir.Properties["AccessWrite"][0] = false;
                    newSiteVDir.Properties["AccessScript"][0] = true;
                    newSiteVDir.Properties["AccessFlags"].Value = 513;
                    newSiteVDir.Properties["AppRoot"][0] = @"/LM/W3SVC/" + Convert.ToString(siteId) + "/Root";
                    newSiteVDir.Properties["AppPoolId"].Value = defaultAppPool;
                    newSiteVDir.Properties["AuthNTLM"][0] = true;
                    newSiteVDir.Properties["AuthAnonymous"][0] = true;
                    newSiteVDir.CommitChanges();
    
                    
                    PropertyValueCollection lstScriptMaps = newSiteVDir.Properties["ScriptMaps"];
                    System.Collections.ArrayList arrScriptMaps = new System.Collections.ArrayList();
                    foreach (string scriptMap in lstScriptMaps)
                    {
                         arrScriptMaps.Add(scriptMap);
                    }
                    newSiteVDir.Properties["ScriptMaps"].Value = arrScriptMaps.ToArray();
                    newSiteVDir.CommitChanges();
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                    
                }
    
                return View("Index");
    
            }
