    using (var fs = File.OpenWrite(filename))
    {
        using (var writer = new BinaryWriter(fs))
        {
            // write sprite count
            writer.Write(spriteList.Count);
            // and write each sprite
            foreach (var s in spriteList)
            {
                writer.Write(sprite.id);
                writer.Write(sprite.size);
                writer.Write(sprite.dump);
            }
        }
    }
