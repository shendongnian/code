    try
    {
        System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
        ofd.Multiselect = false;
        ofd.FileName="";
        if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            filesendpath = ofd.FileName;
            senderfilestream = System.IO.File.Open(filesendpath,System.IO.FileMode.Open);
            sendertotalbytes = senderfilestream.Length;
            filesendcommand = "@File@" + System.IO.Path.GetFileName(filesendpath) + ";" + senderfilestream.Length;
            senderfilestream.Position = 0;
            sendertc.BeginConnect(ip.Address,55502,FileConnect,null);
        }
        else
        {
            //No file selected
        }
        
    }
    catch(Exception ex)
    {
        //Error connecting log the error
    }
