    public partial class GrupaEF : BaseObjectEF
    {
        
        
        private ICollection<KategoriaEF> _Kategorie;
        private ICollection<UzytkownikGrupaEF> _Uzytkownicy;
       
        public virtual ICollection<KategoriaEF> KategorieEF
        {
            get { return _Kategorie; }
            set { _Kategorie = value; }
        }
        public virtual ICollection<UzytkownikGrupaEF> UzytkownicyEF
        {
            get { return _Uzytkownicy; }
            set { _Uzytkownicy = value; }
        }
     
    }
