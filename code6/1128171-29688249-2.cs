    private readonly Decoder _decoder = new Encoding.UTF8.GetDecoder();
    public void on_data_received(IAsyncResult async)
    {
        int byte_count = client_socket_connect.EndReceive(async);
        char[] chars = new char[_decoder.GetCharCount(socket_data_buffer, 0, byte_count)];
        _decoder.GetChars(socket_data_buffer, 0, byte_count, chars, 0);
         //processing data....
        paint_bitmap(1, new string(chars), ex, why);
        wait_for_data();
    }
