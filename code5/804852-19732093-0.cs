    public Display Display
    {
        get
        {
            return new Display
            {
                Description = Description,
                ObjectId = ObjectId,
            };
        }
        set
        {
            Description = value.Description;
            ObjectId = value.ObjectId;
        }
    }
