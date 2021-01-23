        public class HojaDeVida
    {
        public HojaDeVida()
        {
            ExperienciasLaborales = new List<ExperienciaLaboral>();
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public IList<ExperienciaLaboral> ExperienciasLaborales { get; set; }
    }
    public class ExperienciaLaboral
    {
        public string Empresa { get; set; }
        public int Anios { get; set; }
    }
