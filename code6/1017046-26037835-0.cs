    var tasks = new List<Task>();
    
    
        foreach(var computer in computers)
        {
          var t =Task.Factory.StartNew(() =>
                        {
        					BeginScanning(computer);
        					
        					 Acttion myUiStuff = () =>
        					 {
        						toolStripProgressBar1.GetCurrentParent().BeginInvoke(new MethodInvoker(delegate { toolStripProgressBar1.Value++; }));
        						toolStripStatusLabel1.Text = "Scanning of " + computers.Count + " computers(s) completed.";
        					 };
        					 
                             //im assuming you are using WinForms; UI objects must be modified by UI thread so thats is the call to BeginInvoke; If its WPF call the Dispatcher.
        					 BeginInvoke(myUiStuff);
                        }
          tasks.Add(t);
        }
    
        Task.WaitAll(tasks.ToArray());
