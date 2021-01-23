    public Record Fetch(int id)
    {
       // ... get data from db
       Record rec;
       if(data.Type = "Order")
          rec = new Order();
       else
          rec = new Record();
    
       return rec;
    }
