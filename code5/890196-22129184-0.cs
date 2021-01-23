    public int getSumOfTimes()
    {
         int sum;
         if (subordinates.Count() == 0)
         {
           sum =  getIdealTime();
         }
         else
         {
           foreach (var prodel in subordinates)
           {
             sum += prodel.getSumOfTimes();
           }
         }
         return sum;
    }
