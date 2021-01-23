    public async void read()
    {
      using(var dr=new DataReader(_client.InputStream))
      {
        dr.InputStreamOptions=InputStreamOptions.Partial;
        while(true)
        {
          await dr.LoadAsync(1024); //I was missing this line, this is the actual read from the stresm
          byte[] data=new byte[dr.UnconsumedBufferLength];
          dr.ReadBytes(data); //This just interprets the byte read before
          if(data.Length>0)
            CommandReceived.Fire(IComman.FromData(data)); 
          await Task.Delay(15);
        }
      }
    }
