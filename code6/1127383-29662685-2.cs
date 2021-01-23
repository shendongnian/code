        //call via BinaryFileSerialize<Animal>(..., ...);
        public void BinaryFileSerialize<T>(T[] objs, string filePath)
        {
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                  BinaryFormatter b = new BinaryFormatter();
                  b.Serialize(fileStream, objs);
                }
        }
        private Animal[] ReadFile(string filename)
        {
            BinSerializerUtility BinSerial = new BinSerializerUtility();
            var animals = BinSerial.BinaryFileDeSerialize<Animal[]>(filename);
            return animals;
        }
