        ByteArrayClass myFoo = new ByteArrayClass();
        myFoo.FirstArray = new byte[] { 3, 10, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        myFoo.SecondArray = new byte[] { 3, 11, 5, 1, 21, 23, 4, 5, 4, 7, 8, 9, 10 };
        using (FileStream fs = new FileStream(@"C:\Temp\Arry.Bin", 
                              FileMode.Create, FileAccess.Write))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, myFoo);
        }
        ByteArrayInClass newFoo;
        using (FileStream fs = new FileStream(@"C:\Temp\Arry.Bin", 
                            FileMode.Open, FileAccess.Read))
        {
            BinaryFormatter bf = new BinaryFormatter();
            newFoo = (ByteArrayClass) bf.Deserialize(fs);
        }
