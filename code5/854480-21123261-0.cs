    class Data
    {        
        [ProtoMember(1), DefaultValue(null), DisplayName(DisplayNames.ReportName)]
        public string ReportName { get; set; }
        //Check if the reportname was entered
        private void CheckReportName()
        {
        //code to check reportname and generate the errormessage containing the colheader to be sent to grid 
        }
        private static class DisplayNames
        {
            public const string ReportName = "Report Name";
        }
    }    
