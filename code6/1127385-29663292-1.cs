     private Animal[] ReadFile(string filename)
     {
            BinSerializerUtility BinSerial = new BinSerializerUtility();
            var animals = BinSerial.BinaryFileDeSerialize<Animal>(filename);
            return animals.ToArray();
     }
