    // Its members are in the empty namespace
    [DataContract(Namespace = "")] 
    public class OmniLinkExecuteScriptOutput
    {
        [DataMember]
        public string CommonResponse { get; set; }
        [DataMember(Name="reportContent")]
        public string ReportContent { get; set; }
    }
    // Its members are in the DDWEBCallOutput namespace
    [DataContract(Namespace = "http://www.infinity.com/bpm/model/OmniLinkServices/DDWEBCallOutput")] 
    public class OmniLinkExecuteScriptResponseData
    {
        [DataMember(Name = "DDWEBCallOutput")]
        public OmniLinkExecuteScriptOutput Output { get; set; }
    }
    // Its members are in the OmniLinkServices namespace
    [DataContract(Namespace = "http://eclipse.org/stardust/models/generated/OmniLinkServices")] 
    public class OmniLinkExecuteScriptReturn
    {
        [DataMember(Name = "DDWEBCallResponseData")]
        public OmniLinkExecuteScriptResponseData ReponseData { get; set; }
    }
