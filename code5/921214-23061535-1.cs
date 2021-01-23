    private void RemoveFood(List<stationaryFood> foodlist)
    {
        var foodToRemove = new List<stationaryFood>();
        
        foreach(var f in foodlist)
        {
            if(f.FoodLeft == 0)
            {
                foodToRemove.Add(f);
            }
        }
        
        foreach(var f in foodToRemove)
        {
            foodlist.Remove(f);
        }
    }
