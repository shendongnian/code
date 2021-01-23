    [MessageContract(IsWrapped = true, WrapperName = "SaveReportAudio")]
    public class ReportAudioMessage
    {
        [MessageBodyMember]
        public Stream Session;
    }
