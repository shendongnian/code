    var workers = JsonConvert.DeserializeObject<Status>(json);
---
    public class Worker
    {
        public bool alive { get; set; }
        public int hashrate { get; set; }
    }
        
    public class Status
    {
        public string confirmed_rewards { get; set; }
        public int hashrate { get; set; }
        public string payout_history { get; set; }
        public double estimated_rewards { get; set; }
        public Dictionary<string, Worker> workers { get; set; }
        public string efficiency { get; set; }
        public string shares { get; set; }
        public string rewardType { get; set; }
    }
