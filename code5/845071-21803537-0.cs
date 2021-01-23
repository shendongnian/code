    DecodedShortMessage msg = _comm.ReadMessage(ind.Index, ind.Storage);
    SmsStatusReportPdu spdu = pdu as PDU.SmsStatusReportPdu;
    if (spdu != null)
    {
        //do something with the status report
        Console.WriteLine(spdu.RecipientAddress);
    }
