    [Cudafy]
    public struct Texture
    {
        public int Width, Height;
    }
    [Cudafy]
        public static void kernelTest(GThread thread, Texture[] TexStructure, byte[] Data)
        {....}
