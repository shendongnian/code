    try{
    Tamir.SharpSsh.Sftp secureFtp;
    secureFtp = new Tamir.SharpSsh.Sftp(ServerPath, username, password);
    Console.WriteLine("connecting");
    secureFtp.Connect();
    if(secureFtp.Connected)
    {
    Console.WriteLine("Connected");
    secureFtp.Put(Targetpath_filename, DestinationPath_filename);
    //Targetpath_filename = "C:\somepath\somefile.extension
    //DestinationPath_filename = "/in/somefilename.extension" or whatever the ftp path is
    }
    else
    {
    Console.WriteLine("Error connecting");}
    }
    catch(Exception E)
    {
    Console.WriteLine(E.Message);
    }
