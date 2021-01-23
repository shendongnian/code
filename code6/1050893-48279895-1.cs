    public static async Threading.Tasks.Task<string> GetHashAsync<T>(this Stream stream) 
        where T : HashAlgorithm, new()
    {
        StringBuilder sb;
        using (var algo = new T())
        {
            var buffer = new byte[8192];
            int bytesRead;
            // compute the hash on 8KiB blocks
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                algo.TransformBlock(buffer, 0, bytesRead, buffer, 0);
            algo.TransformFinalBlock(buffer, 0, bytesRead);
            // build the hash string
            sb = new StringBuilder(algo.HashSize / 4);
            foreach (var b in algo.Hash)
                sb.AppendFormat("{0:x2}", b);
        }
        return sb?.ToString();
    }
