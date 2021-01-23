    using (BinaryReader b = new BinaryReader(File.Open("file.ext", FileMode.Open)))
    {
        for (int xx = 0; xx < 32; xx += 1)
        {
            for (int yy = 0; yy < 32; yy += 1)
            {
                for (int zz = 0; zz < 4; zz += 1)
                {
                    array[xx, yy, zz] = b.ReadInt32();
                }
            }
        }
    }
