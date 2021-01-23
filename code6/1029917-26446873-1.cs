    var index = new List<long>(spriteList.Count);
    using (var fs = File.OpenWrite(filename))
    {
        using (var writer = new BinaryWriter(fs))
        {
            // write sprite count
            writer.Write(spriteList.Count);
            var indexPos = writer.BaseStream.Position;
            // write index placeholder
            for (var i = 0; i < spriteList.Count; ++i)
            {
                writer.Write(0L);
            }
            // and write each sprite
            for (var i = 0; i < spriteList.Count ++i)
            {
                // save current position
                writer.Flush();
                index[i] = writer.BaseStream.Position;
                writer.Write(sprite.id);
                writer.Write(sprite.size);
                writer.Write(sprite.dump);
            }
            // Seek back to the index position 
            writer.Flush();
            writer.BaseStream.Position = indexPos;
            // and write the real index
            foreach (var pos in index)
            {
                writer.Write(pos);
            }
        }
    }
