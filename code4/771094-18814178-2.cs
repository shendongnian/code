    ArrayList chilProcess_id = new ArrayList();
        
        public void process_starter()
        {            
            Process p;
            p = new System.Diagnostics.Process();           
            p.StartInfo.FileName = "YOUR PROCESS PATH";
            if (!p.Start())
                 chilProcess_id.Add(p.Id);
        }
