    try
    {
        System.Diagnostics.Process.Start(Path) ; 
    }
    catch ( Exception ex)
    {
        MessageBox.Show(ex.Message)  ;
    }
