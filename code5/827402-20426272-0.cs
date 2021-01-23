      ProcessStartInfo info = new ProcessStartInfo();
      System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
      Process proc = new Process();
    
      // uninstalls  application  
      doc.LoadXml("<wap-provisioningdoc>" +
                  "<characteristic type=\"UnInstall\">" +
                            "<characteristic type=\"MyManufactuer  MyApplication\">"+
                              "<parm name=\"uninstall\" value=\"1\"/>" +
                            "</characteristic>" +
                          "</characteristic>" +
                      "</wap-provisioningdoc>");
    
      Microsoft.WindowsMobile.Configuration.ConfigurationManager.ProcessConfiguration(doc, false);
    
      // installs  application  
      info.FileName = @"\windows\wceload.exe";
      info.Arguments = @"\My_Installer.cab";
    
      // start the process
      proc.StartInfo = info;
      proc.Start();
      proc.WaitForExit();
