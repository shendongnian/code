    using (BinaryWriter b = new BinaryWriter(File.Open("file.ext", FileMode.Create)))
    {
        for (int xx = 0; xx < 32; xx += 1)
        {
            for (int yy = 0; yy < 32; yy += 1)
            {
                for (int zz = 0; zz < 4; zz += 1)
                {
                    b.Write(array[xx, yy, zz]);
                }
            }
        }
    }
