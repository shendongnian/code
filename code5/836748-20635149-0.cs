    TimeSpan tsNumberOfDaysToHoldData=TimeSpan.FromDays(5);
    var DataHolder= new Dictionary<DateTime,List<Data>>()
  
    private void AddNewDayData(DateTime NewDay,List<Data> NewData)
    {
       DataHolder[NewDay]=NewData;
       List<DateTime> ExpiredDates=new List<DateTime>();
       foreach(var DayCursor in DataHolder.Keys)
       {
           if(NewDay-DayCursor>tsNumberOfDaysToHoldData)
           {
             ExpiredDates.Add(DayCursor);
           }
       }
       ExpiredDate.ForEach(c=>DataHolder.Remove(c))
     }
