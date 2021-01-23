    public class jQueryDataTableParamModel
    {
        /// <summary>
        /// Request sequence number sent by DataTable,
        /// same value must be returned in response
        /// </summary>       
        public string draw { get; set; }
        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int length { get; set; }
        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int start { get; set; }
    }
