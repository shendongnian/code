        public void printXML(XmlDocument doc)
        {
            var thread = new System.Threading.Thread(new System.Threading.ThreadStart(DelayPrint));
            thread.Start();
        }
        void DelayPrint()
        {
            System.Threading.Thread.Sleep(15000);
            // Do work here
        }
