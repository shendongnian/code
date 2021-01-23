        void loadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Document d = new Document();
            d.Property1 = "Testing";
            d.Property2 = 1;
            d.Property3 = 2;
            e.Result = d;
        }
        void loadBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.LoadedDocument = (Document)e.Result;
            MessageBox.Show("Document loaded with Property1 = " +
                LoadedDocument.Property1 + ", Property2 = " +
                LoadedDocument.Property2 + ", Property3 = " +
                LoadedDocument.Property3);
        }
