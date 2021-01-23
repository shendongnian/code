    public class Objetivo
    {
        public int Id { get; set; }
        public int LocalId { get; set; }
        public DateTime Mes { get; set; }
        public List<ObjetivoItem> Turno1 { get; set; }
        public List<ObjetivoItem> Turno2 { get; set; }
        public List<ObjetivoItem> Unico { get; set; }
    }
