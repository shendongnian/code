        string users = ""; //Really long string goes here
        BinaryFormatter bFormatter = new BinaryFormatter();
        using (MemoryStream resultStream = new MemoryStream())
        {
            using (DeflateStream compressionStream = new DeflateStream(resultStream, CompressionLevel.Optimal, true))
            {
                bFormatter.Serialize(compressionStream, users);
                Console.WriteLine(resultStream.Length); // 0 at this point
            }
            Console.WriteLine(resultStream.Length); // now contains the actual length
        } 
