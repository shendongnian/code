    enum InfoDict {Group, Event, Audience, Type};
    public class FishInformation {
        public int FishId { get; set; }
        private IDictionary<string,int>[] infos = new IDictionary<string,int>[] {
            new Dictionary<string,int>()
        ,   new Dictionary<string,int>()
        ,   new Dictionary<string,int>()
        ,   new Dictionary<string,int>()
        };
        public IDictionary<string,int> GetDictionary(InfoDict index) {
            return infos[index];
        }
    }
