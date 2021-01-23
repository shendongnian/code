      protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
      {
        if (_task != null) 
        { 
          _task.Completed -= OpticalReaderTask_Completed; 
          _task.Dispose(); 
          _task = null; 
        } 
        base.OnBackKeyPress(e);
      }
