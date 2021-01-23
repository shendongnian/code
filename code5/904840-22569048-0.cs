    /// <summary>
    /// Returns the EXIF Image Data of the Date Taken.
    /// </summary>
    /// <param name="getImage">Image (If based on a file use Image.FromFile(f);)</param>
    /// <returns>Date Taken or Null if Unavailable</returns>
    public static DateTime? DateTaken(Image getImage)
    {
        int DateTakenValue = 0x9003; //36867;
            
        if (!getImage.PropertyIdList.Contains(DateTakenValue))
            return null;
    
        string dateTakenTag = System.Text.Encoding.ASCII.GetString(getImage.GetPropertyItem(DateTakenValue).Value);
        string[] parts = dateTakenTag.Split(':', ' ');
        int year = int.Parse(parts[0]);
        int month = int.Parse(parts[1]);
        int day = int.Parse(parts[2]);
        int hour = int.Parse(parts[3]);
        int minute = int.Parse(parts[4]);
        int second = int.Parse(parts[5]);
    
        return new DateTime(year, month, day, hour, minute, second);
    }
