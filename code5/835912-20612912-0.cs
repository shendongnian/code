    private void OpenOFD()
    {
    	Gtk.FileChooserDialog filechooser =
    		new Gtk.FileChooserDialog("Choose the file to open",
    			this,
    			FileChooserAction.Open,
    			"Cancel",ResponseType.Cancel,
    			"Open",ResponseType.Accept);
    
    	if (filechooser.Run() == (int)ResponseType.Accept) 
    	{
    		System.IO.FileStream file = System.IO.File.OpenRead(filechooser.Filename);
    		file.Close();
    	}
    	filechooser.Destroy();
    }
