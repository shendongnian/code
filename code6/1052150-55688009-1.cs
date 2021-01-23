    public class PacketParser
	{
	private List<Session> _TermonatedSessions;
	private IList<Session> _Sessions;
	private IDictionary<int, List<Packet>> _Buffer;
	
	public PacketParser()
    {
        _TermonatedSessions = new List<Session>();
        _Sessions = new List<Session>();
        _Buffer = new Dictionary<int, List<Packet>>();
    }
	
	public void ParsePacket(string filePath)
    {
        OfflinePacketDevice selectedDevice = new OfflinePacketDevice(filePath);
        using (PacketCommunicator communicator = selectedDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000))
        {
            try
            {
                communicator.ReceivePackets(0, AnalyzeCurrentPacket);
            }
            catch { }
        }
        var AnalyzedSession = CombineOpenCloseSessions();
    }
	
	private IList<Session> CombineOpenCloseSessions()
    {
        _TermonatedSessions.AddRange(_Sessions);
        _Sessions.Clear();
        _Buffer.Clear();
        return _TermonatedSessions;
    }
	}
