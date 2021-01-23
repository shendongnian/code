    public static SetTestInfoResponse SetTestData()
    {
        SetTestInfoResponse testDataDs = null;
        TestInformation testInfo = null;
        string stringRequestXML = string.Empty;
        string stringResponseXML = string.Empty;
        //Creates Request packet
        stringRequestXML = XMLCommunicationPackets.SetTestInformation (testInfo, testInfo.TestID, testInfo.TestUser, testInfo.TestSampleType, testInfo.TestSampleId, testInfo.TestMethodNumber, testInfo.TestTubeSn, testInfo.TestComments); 
        //Write set Test Info XML Packet and get response for ack or failure.
        stringResponseXML = PluginContext.GetInstance().InstrumentDriverCurrent.GetInstrumentControl().SetCommonParameter(stringRequestXML);
