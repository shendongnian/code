    class StaffDetail
    {
        public string __type { get; set; }
        public string SessionID { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public object Rows { get; set; }
        [JsonConverter(typeof(ColumnsConverter))]
        public List<string> Columns { get; set; }
        [JsonConverter(typeof(SetConverter))]
        public List<string> Set { get; set; }
    }
