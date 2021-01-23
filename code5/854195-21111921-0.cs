    private void button1_Click(object sender, EventArgs e)
        {
            Task t = new Task(() =>
            {
                lmc.ForEach(l => l.Run());
            
            });
            t.Start();
            t.ContinueWith(_ =>
            {
                Invoke(new System.Action(UploadDone));
            });
           
        }
        private void UploadDone()
        {
            Console.Write("Done");
        }
