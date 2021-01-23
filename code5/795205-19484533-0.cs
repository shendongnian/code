        public class Log
        {
            /// <summary>
            /// Person initiating the contact
            /// </summary>
            public int From { get; set; }
            /// <summary>
            /// Person that was contacted
            /// </summary>
            public int To { get; set; }
        }
        public class SuspectConnection
        {
            public int SuspectId { get; set; }
            public List<int> Contacts { get; set; }
        }
