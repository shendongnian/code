        protected override void OnStart(string[] args)
        {
           
             current_directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            XmlDocument xml = new XmlDocument();
            try
            {
                  string Xml_Path = System.AppDomain.CurrentDomain.BaseDirectory;
                 xml.Load(current_directory+"\\Data.xml");//suppose that myXmlString contains "<Names>...</Names>"
                    XmlNodeList xnList = xml.SelectNodes("/Names/Name");
                     foreach (XmlNode xn in xnList)
                     {
                         strDir = xn["Directory"].InnerText;
                         fileMask = xn["FileMask"].InnerText;
                         strBatfile = xn["Batch"].InnerText;
                         strlog = xn["Log"].InnerText;
                     }
                m_Watcher = new FileSystemWatcher();
                m_Watcher.Filter = fileMask;
                m_Watcher.Path = strDir + "\\";
                m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                m_Watcher.Created += new FileSystemEventHandler(OnCreated);
                m_Watcher.Deleted += new FileSystemEventHandler(OnDeleated);
                m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
                m_Watcher.EnableRaisingEvents = true;
            }
            catch (Exception exception)
            {
                CustomException.Write(CustomException.CreateExceptionString(exception.ToString()));
            }
        }
