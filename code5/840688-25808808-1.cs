        private void SomeLongOperation()
    {
       // long operations...
    
       // UI update
          label1.Content = someValue;
          label1.Refresh();
       
       // continue long operations   
       }
    }
