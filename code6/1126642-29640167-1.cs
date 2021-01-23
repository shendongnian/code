    private void SaveToFile(string filename)
    {
        //Animal array
        Animal [] animals = new Animal[animalmgr.Count];
        for (int index = 0; index < animalmgr.Count; index++)
        {
            animals[index] = animalmgr.GetAt(index);
        }
        BinSerializerUtility BinSerial = new BinSerializerUtility();
        BinSerial.BinaryFileSerialize(animals, filename);
    }
