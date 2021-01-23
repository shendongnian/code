    [DataContract]
    [Route("/PiecParametrySzczegolowe")]
    public class PiecParametrySzczegoloweRequest : IReturn<PiecParametrySzczegoloweResponse>
    {
        [DataMember]
        public bool Initialize { get; set; }
        [DataMember]
        public PiecParametrySzczegoloweLegend Config { get; set; }
        [DataMember]
        public int Percent { get; set; }
    }
