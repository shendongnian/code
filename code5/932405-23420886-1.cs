    // configure the model; SupportNull is not currently available
    // on the attributes, so need to tweak the model a little
    RuntimeTypeModel.Default.Add(typeof(SerializableFactors), true)[1].SupportNull = true;
    if (File.Exists("factors.bin"))
    {
       using (FileStream file = File.OpenRead("factors.bin"))
       {
          _factors = Serializer.Deserialize<SerializableFactors>(file);
       }
    }
    else
    {
       _factors = new SerializableFactors();
       _factors.CaF = new double?[24];
       _factors.CaF[8] = 7.5;
       _factors.CaF[12] = 1;
       _factors.CaF[18] = 1.5;
       _factors.CoF = new byte?[24];
       _factors.CoF[8] = 15;
       _factors.CoF[12] = 45;
       _factors.CoF[18] = 25;
       using (FileStream file = File.Create("factors.bin"))
       {
         Serializer.Serialize(file, _factors);
       }
    }
