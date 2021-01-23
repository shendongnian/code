    public static DateTime ConvertToDate(int intDateTime){
      DateTime dt = null;
      //Convert int to String
      String tempDate = intDateTime.toString();
      int year = 0;
      int month = 1;
      int day = 1;
      //Basic check if length = 4, set year. NOTE no validation that year is reasonable.
       if(tempDate.Length  == 4)
       {
          year = Convert.ToInt32(tempDate);
       }else if(tempDate.Length  == 6){
          year = Convert.ToInt32(tempDate.Substring(0,3);
          month = Convert.ToInt32(tempdate.Substring(4,5);
       }else if(tempDate.Length == 8){
          year = Convert.ToInt32(tempDate.Substring(0,3);
          month = Convert.ToInt32(tempdate.Substring(4,5);
          day = Convert.ToInt32(tempdate.Substring(6,7);
       }
       return dt = new DateTime(year, month, day);
    }
