    class CallCenterActivity
    {
        public CallCenterActivity(string callActivity)
        {
            AgentStistics = new List<AgentStatistic>();
            using(var reader = new StringReader(callActivity))
            {
                 ActivityDate = ParseActivityDate(reader.ReadLine());
                 MaxAgents = ParseInt(reader.ReadLine());
                 MinAgents = ParseInt(reader.ReadLine());
                 //(Snip)
                 AvarageTimeBeforeAbandon = ParseInt(reader.ReadLine());
                 if(reader.ReadLine().Trim().Equals("Per agent statistics:") == false)
                     throw new InvalidDataException("We where not on the line we expected to be for \"Per Agent statistics:\"");
                 string currentLine;
                 //This loops till we break out of the agent section
                 while((currentLine = reader.ReadLine()).Trim().Equals("Queue related statistics:")
                 {
                      var agent = new AgentStatistic();
                      agent.AgentId = ParseInt(reader.ReadLine());
                      agent.DirectCallsAnswered = ParseInt(reader.ReadLine());
                      //(snip)
                      agent.QueueLongestTimeInCall = ParseInt(reader.ReadLine());
                     
                      AgentStistics.Add(agent);
                 }
                 TotalCallsPresentedToQueue = ParseInt(reader.ReadLine());
                 //(Snip)
                 CallsAnsweredByVoiceMail = ParseInt(reader.ReadLine());
            }
        }
        //These "parser methods are small and kept static so you could easily write unit tests against each parser.
        private static DateTime ParseActivityDate(string activityDateLine)
        {
            throw new NotImplmentedException("Here you would turn your \"Fri 11:00 - 12:00\" in to a DateTime");
        }
        private static int ParseInt(string line)
        {
            var split = line.Split(':')
            return Int.Parse(split[1]);
        }
        public DateTime ActivityDate {get;set;} //Assume I put "public VariableName {get;set}" on the rest of the members, I am just saving typing
        int MaxAgents
        int MinAgents
        int TotalCalls
        int AnsweredCalls
        int AbandonedCalls
        int AvarageTimeToAnswer
        int LongestTimeToAnswer
        int AvarageTimeBeforeAbandon
        List<AgentStatistic> AgentStistics {get; private set;}
        int TotalCallsPresentedToQueue
        int CallsAnsweredByAgents
        int NumberOfCallsInTheQueue
        int AvarageTimeToAnswerQueue
        int LongestTimeToAnswerQueue
        int NumberOfAbandondCalls
        int AvarageTimeBeforeAbandon
        int CallsForwaredToVoiceMail
        int CallsAnsweredByVoiceMail
    }
    class AgentStatistic
    {
        int AgentId {get;set;}
        int DirectCallsAnswered {get;set;}
        int DirectCallsAverageTimeInCall {get;set;}
        int DirectCallsLongestTimeInCall {get;set;}
        int QueueAnswered {get;set;}
        int QueueAverageTimeInCall {get;set;}
        int QueueLongestTimeInCall {get;set;}
    }
