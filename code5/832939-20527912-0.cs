    public class StatisticsTotals
    {
        public string RunTime { get; set; }
        public string RunTimeRank { get; set; }
        public string Points { get; set; }
        public string PointsRank { get; set; }
        public string Results { get; set; }
        public string ResultsRank { get; set; }
    }
    
    public class StatisticsAverages
    {
        public string RunTimePerDay { get; set; }
        public string RunTimePerResult { get; set; }
        public string PointsPerHourRunTime { get; set; }
        public string PointsPerDay { get; set; }
        public string PointsPerResult { get; set; }
        public string ResultsPerDay { get; set; }
    }
    
    public class Resource
    {
        public string Url { get; set; }
        public string Description { get; set; }
    }
    
    public class MemberStat
    {
        public string Name { get; set; }
        public string MemberId { get; set; }
        public string TeamId { get; set; }
        public string RegisterDate { get; set; }
        public string LastResult { get; set; }
        public string NumDevices { get; set; }
        public StatisticsTotals StatisticsTotals { get; set; }
        public StatisticsAverages StatisticsAverages { get; set; }
        public Resource Resource { get; set; }
    }
    
    public class MemberStats
    {
        public MemberStat MemberStat { get; set; }
    }
    
    public class StatisticsTotals2
    {
        public string RunTime { get; set; }
        public string Points { get; set; }
        public string Results { get; set; }
    }
    
    public class Team
    {
        public string Name { get; set; }
        public string TeamId { get; set; }
        public string JoinDate { get; set; }
        public StatisticsTotals2 StatisticsTotals { get; set; }
    }
    
    public class TeamHistory
    {
        public Team Team { get; set; }
    }
    
    public class Project
    {
        public string ProjectName { get; set; }
        public string ProjectShortName { get; set; }
        public string RunTime { get; set; }
        public string Points { get; set; }
        public string Results { get; set; }
    }
    
    public class MemberStatsByProjects
    {
        public List<Project> Project { get; set; }
    }
    
    public class MemberStatsWithTeamHistory
    {
        public MemberStats MemberStats { get; set; }
        public TeamHistory TeamHistory { get; set; }
        public MemberStatsByProjects MemberStatsByProjects { get; set; }
    }
    
    public class RootObject
    {
        public MemberStatsWithTeamHistory MemberStatsWithTeamHistory { get; set; }
    }
