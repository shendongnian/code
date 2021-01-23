     public partial class GrupaEF : IGrupa
    {
       
        public string Nazwa
        {
            get
            {
                return this.Nazwa;
            }
            set
            {
                this.Nazwa = value;
            }
        }
       
        public string Opis
        {
            get { return Opis; }
            set { Opis = value; }
        }
        [NotMapped]
        public ICollection<IKategoria> Kategorie
        {
            get
            {
                return (ICollection<IKategoria>)this.KategorieEF;
            }
            set { KategorieEF = (ICollection<KategoriaEF>)value; }
        }
        [NotMapped]
        public ICollection<IUzytkownikGrupa> Uzytkownicy
        {
            get { return (ICollection<IUzytkownikGrupa>)this.UzytkownicyEF; }
            set { UzytkownicyEF = (ICollection<UzytkownikGrupaEF>)value; }
        }
    }
