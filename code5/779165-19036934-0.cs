    using(StreamReader objReader = new StreamReader("file_location"))
    {
        do
        {
            sLine = objReader.ReadLine();
            
            if(sLine != null)
            //do stuff
         }
         while(!objReader.EndOfStream);
         
     }
