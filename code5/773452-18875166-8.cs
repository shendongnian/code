    public static byte[] Append(this byte[] dst, byte[] src)
    {
        Array.Resize(ref dst, dst.Length + src.Length);
        Array.Copy(src, 0, dst, dst.Length - src.Length,src.Length);
        return dst;
    }
