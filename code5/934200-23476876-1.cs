    public void RecordConversation(ref ChannelResource cr)
    {
        cr = new ChannelResource();
        VoiceResource RecordResource = TServer.GetVoiceResource();
        RecordResource.MaximumTime = 6000;
        RecordResource.MaximumSilence = 6000;
        RecordResource.TerminationDigits = "";
    }
