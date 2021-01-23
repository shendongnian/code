    private volatile bool _continue = false;
    
    private void CopyClicked(Object sender, EventArgs e)
    {
       _continue = true;
       System.Threading.ThreadStart ts = new ThreadStart(CopyFiles);
       System.Threading.Thread t = new Thread(ts);
       t.Start();
    }
    private void CopyFiles(){
       List<String> list = GetFileNames();
       foreach( String f in list )
       {
          if ( _continue == false )
          {
            return;
          }
          CopyFile(s);  //examples...
       }
    }
    private void CancelClicked(Object sender, EventArgs e)
    {
        _continue = false;
        Close();
    }
   
