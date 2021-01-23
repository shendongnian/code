    public class TemplateDataText{
        public TemplateDataText(){}
        [JsonProperty("text")]
        public string templateMsgText { get; set; }
    
        [JsonProperty("optionSelected")]
        public string radioSelected { get; set; }
        
    }
