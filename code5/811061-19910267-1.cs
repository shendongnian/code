    public int FoodID { get; set; }
    public Food Food
    {
        get
        {
            return Food.Fetch(FoodID);
        }
    }
