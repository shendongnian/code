    protected DateTime CheckDate(String date)
    {
      DateTime dt;
     try{
        dt = DateTime.Parse(date);
     }catch(Exception ex){
        dt = DateTime.now();
        // may raise an exception
    }
      finally{
          return dt;
      }
     }
