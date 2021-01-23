        sw = File.Open(@"C:\Players.bin", FileMode.Append);
        for (int x = 0; x < size; x++)
        {
            bf.Serialize(sw, playerArr[x]);
        }
        sw.Close(); 
