    public void WriteInt(int v)
    {
        ClientOutput.Write ((byte)(((uint)v >> 24) & 0xFF));
        ClientOutput.Write ((byte)(((uint)v >> 16) & 0xFF));
        ClientOutput.Write ((byte)(((uint)v >> 8) & 0xFF));
        ClientOutput.Write ((byte)(((uint)v >> 0) & 0xFF));
        IncCount (4);
    }
