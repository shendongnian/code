    // a class to work with the listbox:
    class proc
    {
        public Process process { get; set; }
        public proc (Process process_) {process = process_;}
        public override string ToString() { return process.MainWindowTitle; }
    }
    
    // a button-click to fill/refresh the list:
    private void cb_refresh_Click(object sender, EventArgs e)
    {
        lb_processes.Items.Clear();
    
        var allProcceses = Process.GetProcesses();
        foreach (Process process in allProcceses)
        {
            if (!string.IsNullOrEmpty(process.MainWindowTitle))
                lb_processes.Items.Add(new proc(process));
        }
    }
    
    
    // the event to display the icon:
    private void lb_processes_SelectedIndexChanged(object sender, EventArgs e)
    {
        Process p = ((proc)lb_processes.SelectedItem).process;
        // the process list is cached -> refresh & leave if a process has ended!  
        if (p.HasExited)
        {
            MessageBox.Show("This process has exited!", p.MainWindowTitle);
            cb_refresh_Click(null, null);
            return;
        }
        try
        {
            pb_icon.Image = Icon.ExtractAssociatedIcon(p.MainModule.FileName).ToBitmap(); 
        } 
        catch (Exception ex) 
        { 
          // expected errors if there is no icon or the process is 64-bit
          if (ex is ArgumentException || ex is Win32Exception )
          {
            pb_icon.Image = pb_icon.Image = Bitmap.FromHicon(SystemIcons.Application.Handle); 
          }
          else
          {
            pb_icon.Image = pb_icon.Image = Bitmap.FromHicon(SystemIcons.Error.Handle); 
            throw;
          }
        }
