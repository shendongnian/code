    public class Prod
    {
        private ICollection<ProdLang> _prodLangs;
        public ICollection<ProdLang> ProdLangs 
        {
            get{ return _prodLangs.OrderBy(p => p.Name).ToList(); }
            set{ _prodLangs = value; }
        }
    }
