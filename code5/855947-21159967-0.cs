               using (BinaryReader b = new BinaryReader(File.Open(@"filed", FileMode.Open)))
            {
                Int64 tomtomID;
                Int32 grafoID;
                int numArchi = b.ReadInt32();
                edgeID = new Dictionary<long, int>(numArchi);
                for (int i = 0; i < numArchi; i++)
                {
                    tomtomID = (b.ReadInt64());
                    grafoID = b.ReadInt32();
                    edgeID[keyID] = grafoID;
                }
            }
        }
