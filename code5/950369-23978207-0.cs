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
        try
        {
            string exe = ((proc)lb_processes.SelectedItem).process.MainModule.FileName;
            pb_icon.Image = Icon.ExtractAssociatedIcon(exe).ToBitmap(); 
        } 
        catch (Exception ex) // you could check the error codes or always shoe the default:
        { 
            pb_icon.Image = pb_icon.Image = Bitmap.FromHicon(SystemIcons.Application.Handle);
        }
    }
