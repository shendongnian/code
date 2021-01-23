    public bool function(string buf)
		{ 
            string[] lineSplit = buf.Split(new string[] { "//" }, StringSplitOptions.None);
	
          if (lineSplit[0] != string.Empty)
			{
				return true;
			}
			return false;
		}
