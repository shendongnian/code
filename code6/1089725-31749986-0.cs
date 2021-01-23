    bool getHeader = True;
    int header_size = 4+2+4+2;
    int payload_size = 0;
    byte[] header = new byte[header_size];
    byte[] buffer = new byte[255];
    int rec;
    while (true)
    {
        if(getHeader)
        {
            rec = sck.Receive(header, 0, header_size, 0);
            payload_size = ..... parse header[4] & header[5] to payload size (int)
            getHeader = False;
        }else{
            rec = sck.Receive(buffer, 0, payload_size, 0);
            getHeader = True;
        }  
    }
