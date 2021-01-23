    using System.Runtime.Serialization;
    namespace OperationsAPI.Models
    {
        [DataContract]
        public partial class Intervention
        {
            public int intervention_id { get; set; }
            public int technician_id { get; set; }
            public int client_id { get; set; }
            public string type { get; set; }
            public int done { get; set; }
            public int year { get; set; }
            [DataMember]
            public int month { get; set; }
            [DataMember]
            public int week { get; set; }
            [DataMember]
            public Nullable<int> avg_response_time { get; set; }
            public int number_of_equip { get; set; }
            [DataMember]
            public virtual Client Client { get; set; }
            public virtual Technician Technician { get; set; }
        }
    }
