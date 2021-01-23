    UdpTarget target = new UdpTarget(IPAddress.Parse("192.168.1.1"));
    Pdu pdu = new Pdu(PduType.Get);
    pdu.VbList.Add("1.3.6.1.2.1.1.3.0");
    AgentParameters param = new AgentParameters(SnmpVersion.Ver1, new OctetString("public"));
    SnmpV1Packet packet = (SnmpV1Packet)target.Request(pdu, param);
    AsnType uptimeAsn = packet.Pdu.VbList["1.3.6.1.2.1.1.3.0"].Value;
    long uptime = ((TimeTicks)uptimeAsn).Milliseconds;
    Console.WriteLine(uptime);
    Console.WriteLine(new TimeSpan(0,0,(int)(uptime/1000)));
