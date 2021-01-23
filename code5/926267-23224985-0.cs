    public void Write(dynamic val) 
    {
        if (binWriter != null)
        {
            binWriter.Write(val);
        }
    }
