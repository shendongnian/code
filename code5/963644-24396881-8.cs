    // helper method to get the packet length
    public int GetPacketLength(char c)
    {
        switch(c)
        {
            case 'A':
                return 5;
            case 'B':
                return 6;
            case 'C':
                return 7;
            default:
                throw new Exception("Unknown packet code");
        }
    }
