    public Image ReturnDbImage()
    {
    	var dbBinary = (from s in db.Image_tables
    		       where s.Id ==1
      		       select s.imag).FirstOrDefault();
    	if (dbBinary == null)
    	{
    		//Handle the issue
    	}
    	else
    	{
    		using (var ms = new MemoryStream(dbBinary.ToArray()))
    		{
    			Image img = Image.FromStream(ms);
    			return img;
    		}
    	}
    }
