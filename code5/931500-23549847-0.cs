    class Program
    {           
        private ConcurrentDictionary<string, string> schemaStore =
                new ConcurrentDictionary<string, string>();
        static void Main(string[] args)
        {
            Program p = new Program();
            for (int i = 0; i < 40;i++ )
                new Thread(new ThreadStart(p.validate)).Start();
            Console.ReadKey();
        }
        public void validate()
        {
            
            string xmlFile = "XMLFile1.xml";
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            //settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            //settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler +=
                new ValidationEventHandler(ValidationCallBack);
            
            
                using (var tr = new XmlTextReader(xmlFile))
                {
                    tr.MoveToContent();
                    var url = tr.GetAttribute("xsi:noNamespaceSchemaLocation");
                    string schemaXml =null;
                    if (!schemaStore.TryGetValue(url, out schemaXml))
                    {
                        //Console.WriteLine("Need download");
                        using (System.Net.WebClient wc = new System.Net.WebClient())
                        {
                            string schemadata = wc.DownloadString(url);
                            schemaStore.TryAdd(url, schemadata);
                            schemaXml = schemadata;
                            
                        }
                    }else
                    {
                            //Console.WriteLine("Cache hit");
                    }
                    XmlSchema schema = XmlSchema.Read(new StringReader(schemaXml), (sender, args) => { });
                    settings.Schemas.Add(schema);
                    
                }
            
         
            using (XmlReader reader = XmlReader.Create(xmlFile, settings))
            {
               
                while (reader.Read()) ;
            }
            Console.WriteLine("Thread "+Thread.CurrentThread.ManagedThreadId+" completes");
        }
        private void ValidationCallBack(object sender, ValidationEventArgs args)
        {           
                if (args.Severity == XmlSeverityType.Error)
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId + " -> Error: " + args.Message);
                else
                    Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId + " -> Warning: " + args.Message);          
        }
        
        
    }
