    public void UpdateBatteryState(BatteryItem batItem, BatteryState state)
    {
        try
        {
            context.BatteryItem.Add(batItem);
            batItem.state = state.ToString();
    
            context.SaveChanges()
         }
         catch (Exception e)
         {
             Console.WriteLine(e.Message);
         }
    }
