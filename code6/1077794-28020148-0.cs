    [DataContract]
    public class WytypowaneMecze
    {
        public WytypowaneMecze() { }
        public WytypowaneMecze(String data, String d_gospodarzy, String d_gosci, String wynik)
        {
            this.Data = data;
            this.D_gospodarzy = d_gospodarzy;
            this.D_gosci = d_gosci;
            this.Wynik = wynik;
        }
        [DataMember]
        public string Data { get; set; }
        [DataMember]
        public string D_gospodarzy { get; set; }
        [DataMember]
        public string D_gosci { get; set; }
        [DataMember]
        public string Wynik { get; set; }
    }
