        try {
	foreach (Process proc in Process.GetProcessesByName("Excel"))
            {
                proc.Kill();
            }}catch(Exception ex){
	MessageBox.Show(ex.Message);}
