    public String RemoveSpaces(String withSpaces){
        StringBuilder sb = new StringBuilder();
    
        for (int i = 0; i < withSpaces.Length; i++)
        {
            if (withSpaces[i] != 32)
            {
               sb.Append(withSpaces[i]);
            }
        }
    
        return sb.ToString();
    }
