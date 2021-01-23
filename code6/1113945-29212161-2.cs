    public bool Populate(ref List<car> carList)
    {
        //do some stuff to connect to database
        AseDataReader reader = GetReader();
        readCarInformation(reader, ref carList);
    }        
    public bool Populate(ref List<bike> bikeList)
    {
        //do some stuff to connect to database
        AseDataReader reader = GetReader();
        readBikeInformation(reader, ref bikeList);
    }
