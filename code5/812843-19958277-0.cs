    Protocol protocol;
    if(Enum.TryParse(GetFromProtocolTypeFromDB(), out protocol)
    {
        switch (protocol)
        {
            case Protocol.Http:
                {
                    break;
                }
            case Protocol.Ftp:
                {
                    break;
                }
            // perhaps a default
        }
    } // perhaps an else
