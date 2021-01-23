        public interface IUserSettings
        {
            int Value1 { get; }
            string Value2 { get; }
        }
        public class UserSettings : IUserSettings
        {
            public int Value1 { get; set; }
            public string Value2 { get; set; }
        }
