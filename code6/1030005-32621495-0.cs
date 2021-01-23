    private byte[] buffer = new byte[8192];
    private int payloadLength;
    private int payloadPosition;
    private MemoryStream packet = new MemoryStream();
    private PacketReadTypes readState;
    private Stream stream;
        
    private void ReadCallback(IAsyncResult ar)
    {
        try
        {
            int available = stream.EndRead(ar);
            int position = 0;
            while (available > 0)
            {
                int lengthToRead;
                if (readState == PacketReadTypes.Header)
                {
                    lengthToRead = (int)packet.Position + available >= SessionLayerProtocol.HEADER_LENGTH ?
                            SessionLayerProtocol.HEADER_LENGTH - (int)packet.Position :
                            available;
                    packet.Write(buffer, position, lengthToRead);
                    position += lengthToRead;
                    available -= lengthToRead;
                    if (packet.Position >= SessionLayerProtocol.HEADER_LENGTH)
                        readState = PacketReadTypes.HeaderComplete;
                }
                if (readState == PacketReadTypes.HeaderComplete)
                {
                    packet.Seek(0, SeekOrigin.Begin);
                    BinaryReader br = new BinaryReader(packet, Encoding.UTF8);
                    ushort protocolId = br.ReadUInt16();
                    if (protocolId != SessionLayerProtocol.PROTOCAL_IDENTIFIER)
                        throw new Exception(ErrorTypes.INVALID_PROTOCOL);
                    payloadLength = br.ReadInt32();
                    readState = PacketReadTypes.Payload;
                }
                if (readState == PacketReadTypes.Payload)
                {
                    lengthToRead = available >= payloadLength - payloadPosition ?
                        payloadLength - payloadPosition :
                        available;
                    packet.Write(buffer, position, lengthToRead);
                    position += lengthToRead;
                    available -= lengthToRead;
                    payloadPosition += lengthToRead;
                    if (packet.Position >= SessionLayerProtocol.HEADER_LENGTH + payloadLength)
                    {
                        if (Logger.LogPackets)
                            Log(Level.Debug, "RECV: " + ToHexString(packet.ToArray(), 0, (int)packet.Length));
                        MemoryStream handlerMS = new MemoryStream(packet.ToArray());
                        handlerMS.Seek(SessionLayerProtocol.HEADER_LENGTH, SeekOrigin.Begin);
                        BinaryReader br = new BinaryReader(handlerMS, Encoding.UTF8);
                        if (!ThreadPool.QueueUserWorkItem(OnPacketReceivedThreadPoolCallback, br))
                            throw new Exception(ErrorTypes.NO_MORE_THREADS_AVAILABLE);
                        Reset();
                    }
                }
            }
            stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(ReadCallback), null);
        }
        catch (ObjectDisposedException)
        {
            Close();
        }
        catch (Exception ex)
        {
            ConnectionLost(ex);
        }
    }
        
    private void Reset()
    {
        readState = PacketReadTypes.Header;
        packet = new MemoryStream();
        payloadLength = 0;
        payloadPosition = 0;
    }
