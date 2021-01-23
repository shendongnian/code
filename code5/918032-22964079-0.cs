    public class Config {
        public string SomeSetting { get; set; }
        public override string ToString() {
            return string.Format("SomeSetting = {0}", SomeSetting);
        }
    }
