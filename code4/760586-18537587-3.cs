    class CallCenterActivity
    {
        public CallCenterActivity(string callActivity)
        {
            AgentStistics = new List<AgentStatistic>();
            using(var reader = new StringReader(callActivity))
            {
                 ActivityDate = ParseActivityDate(reader.ReadLine());
                 MaxAgents = ExtractInt(reader);
                 MinAgents = ExtractInt(reader);
                 //(Snip)
                 AvarageTimeBeforeAbandon = ExtractInt(reader);
                 if(reader.ReadLine().Trim().Equals("Per agent statistics:") == false)
                     throw new InvalidDataException("We where not on the line we expected to be for \"Per Agent statistics:\"");
                 string currentLine;
                 //This loops till we break out of the agent section
                 while((currentLine = reader.ReadLine()).Trim().Equals("Queue related statistics:") == false)
                 {
                      var agent = new AgentStatistic();
                      agent.AgentId = ExtractInt(reader);
                      agent.DirectCallsAnswered = ExtractInt(reader);
                      //(snip)
                      agent.QueueLongestTimeInCall = ExtractInt(reader);
                     
                      AgentStistics.Add(agent);
                 }
                 TotalCallsPresentedToQueue = ExtractInt(reader);
                 //(Snip)
                 CallsAnsweredByVoiceMail = ExtractInt(reader);
            }
        }
        //These parser methods are small and kept static so you could easily write unit tests against each parser.
        private static DateTime ParseActivityDate(string activityDateLine)
        {
            throw new NotImplmentedException("Here you would turn your \"Fri 11:00 - 12:00\" in to a DateTime");
        }
        //ParseInt and ExtractInt are separated to ease Unit Testing.
        private static int ParseInt(string line)
        {
            var split = line.Split(':')
            return Int32.Parse(split[1]);
        }
        private static int ExtractInt(StringReader reader)
        {
            return ParseInt(reader.ReadLine());
        }
        public DateTime ActivityDate {get;set;}
        public int MaxAgents {get;set;}
        public int MinAgents {get;set;}
        public int TotalCalls {get;set;}
        public int AnsweredCalls {get;set;}
        public int AbandonedCalls {get;set;}
        public int AvarageTimeToAnswer {get;set;}
        public int LongestTimeToAnswer {get;set;}
        public int AvarageTimeBeforeAbandon {get;set;}
        public List<AgentStatistic> AgentStistics {get; private set;}
        public int TotalCallsPresentedToQueue {get;set;}
        public int CallsAnsweredByAgents {get;set;}
        public int NumberOfCallsInTheQueue {get;set;}
        public int AvarageTimeToAnswerQueue {get;set;}
        public int LongestTimeToAnswerQueue {get;set;}
        public int NumberOfAbandondCalls {get;set;}
        public int AvarageTimeBeforeAbandon {get;set;}
        public int CallsForwaredToVoiceMail {get;set;}
        public int CallsAnsweredByVoiceMail {get;set;}
    }
    class AgentStatistic
    {
        public int AgentId {get;set;}
        public int DirectCallsAnswered {get;set;}
        public int DirectCallsAverageTimeInCall {get;set;}
        public int DirectCallsLongestTimeInCall {get;set;}
        public int QueueAnswered {get;set;}
        public int QueueAverageTimeInCall {get;set;}
        public int QueueLongestTimeInCall {get;set;}
    }
