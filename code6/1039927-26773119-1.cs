        public void printXML(XmlDocument doc)
        {
            var thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(DelayPrint));
            thread.Start(doc);
        }
        void DelayPrint(object param)
        {
            System.Threading.Thread.Sleep(15000);              
            XmlDocument doc = param as XmlDocument;
            // Do Work
        }
