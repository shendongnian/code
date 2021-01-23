    public List<List<calendarData>> getCalList()
    {
        List<List<calendarData>> StaticData = new List<List<calendarData>> 
        {
            new List<calendarData> 
            {
                new calendarData
                {
                    name = "Jon Jon",
                    shortName = "Jon",
                    HOURstartDT = DateTime.Now.Date.AddDays(-1)
                }
            },
    
            new List<calendarData> 
            {
                new calendarData
                {
                    name = "Steve Steve",
                    shortName = "Steve",
                    HOURstartDT = DateTime.Now.Date
                }
            },
    
            new List<calendarData> 
            {
                new calendarData
                {
                    name = "Michael Michael",
                    shortName = "Michael",
                    HOURstartDT = DateTime.Now.Date
                }
            }
        };
    
        //return StaticData.GroupBy(x => x.FirstOrDefault().HOURstartDT).Select(x => x.ToList()).ToList();
        return StaticData.SelectMany(x => x).ToList().GroupBy(x => x.HOURstartDT).Select(x => x.ToList()).ToList();
    }
