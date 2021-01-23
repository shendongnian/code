    foreach (var a in mail.Attachments)
    {
        FileAttachment fa = a as FileAttachment;
        if(fa != null)
        {
            try
            {
                //if you don't call this the Content property may be null,
                //depending on your property loading policy with EWS
                fa.Load();
            }
            catch 
            {
                continue;
            }
    	
            using(FileStream fs = System.IO.File.OpenWrite("path_to_file"))
            {
    	        fs.Write(fa.Content, 0, fa.Content.Length);
            }
        }
    }
