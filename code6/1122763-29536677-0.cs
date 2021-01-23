    System.Windows.Forms.Timer heapMinimizerTimer = new System.Windows.Forms.Timer();
                heapMinimizerTimer.Interval = (2 * 60 * 1000); // 2 mins
                heapMinimizerTimer.Tick += new EventHandler(heapMinimizerTimer_Tick);
                heapMinimizerTimer.Start();
    
    
      private void heapMinimizerTimer_Tick(object sender, EventArgs e)
            {
                var _memoryService = Xpcom.GetService<nsIMemory>("@mozilla.org/xpcom/memory-service;1");
                _memoryService.HeapMinimize(false);
            }
