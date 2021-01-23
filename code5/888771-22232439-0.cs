        class Timeout
        {
            XmlDocument doc;
            System.Object input;
            public Timeout(XmlDocument doc, System.Object input)
            {
                this.doc = doc;
                this.input = input;
            }
            public void run()
            {
                if (input is Stream)
                {
                    doc.Load((Stream)input);
                }
                else if (input is XmlReader)
                {
                    doc.Load((XmlReader)input);
                }
                else if (input is TextReader)
                {
                    doc.Load((TextReader)input);
                }
                else
                {
                    doc.Load((string)input);
                }
            }
        }
        private void LoadXmlDoc(XmlDocument doc, System.Object input)
        {
            Timeout timeout = new Timeout(doc, input);
            System.Threading.Thread timeoutThread = new System.Threading.Thread(new ThreadStart(timeout.run));
            timeoutThread.Name = "XmlWorker" + threadNumber++;
            timeoutThread.Start(); 
            if (!timeoutThread.Join(this.timeout)) //Join returning false implies the timeout was reached
            {
                if (timeoutThread.IsAlive)
                    timeoutThread.Abort();
                throw new DataConnectionException("timeout reached: " + this.timeout.Milliseconds + "ms", new TimeoutException(this.timeout.Milliseconds));
            }
        }
