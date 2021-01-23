    public void FilBuff<T>(T p_tInput) 
    {
        if(typeof(T) == typeof(string))
        {
            m_bBuff = System.Text.Encoding.ASCII.GetBytes((string)p_tInput);
        }
    }
