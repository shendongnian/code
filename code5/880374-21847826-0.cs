    public static string IncludeCentury(this DateTime sourceDate, bool replace)
    {
      var source = String.Format("{0}/{1}", sourceDate.Year / 100 + 1, sourceDate);
      if(replace)
   	    return Regex.Replace(source, "[^0-9]", "");
      else
        return source;
    }
