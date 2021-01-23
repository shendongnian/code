    protected void Total(DataTable dt)
    {
        string label;
        double size = 0;
    
        foreach (DataRow row in dt.Rows)
        {
            var result = Regex.Match(row["Size"].ToString(),@"([0-9]+)(.*)");
            var fileSize = Convert.ToInt32(result.Groups[0].Value);
            var type = result.Groups[1].Value;
    
            switch (type)
    	    {
                case "B":
                    size += ConvertBytesToMegabytes(fileSize);
                    break;
                case "KB":
                    size += ConvertKilobytesToMegabytes(fileSize);
                    break;
                case "MB":
                    size += fileSize;
                    break;
                //ETC...
    	        default:
                    break;
    	    }
        }
        label = dt.Rows.Count +" attachments " + size.ToString();       
    }
