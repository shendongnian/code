    public class HorarioFixo : Horario
    {
        public virtual int Frequencia { get; set; }
        public virtual ICollection<JanelaHorarioFixo> Janelas { get; set; }
    }
