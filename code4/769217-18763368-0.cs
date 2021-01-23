    [OnDeserialized]
    internal void OnSerializingMethod(StreamingContext context)
    {
        if(ListOfTwo == null) {
            ListOfTwo = new List<Two>();
        }
    }
