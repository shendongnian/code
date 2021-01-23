    class BusData
    {
        public int SortWeight
        {
            get
            {
                switch(this.WeekDay)
                {
                     case "Monday": return 0;                        
                     case "Tuesday": return 1;
                     // ... add more days here
                }
                return 7;
            }
        }
    }
