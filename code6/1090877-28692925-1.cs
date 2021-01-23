        public partial class UrunIslem : Window
    {
        public static ObservableCollection<UrunGrubu> urun_grubu_listesi { get; set; }
        public static ObservableCollection<Yazici> yazici_listesi { get; set; }
        public static ObservableCollection<Vergi> vergi_listesi { get; set; }
        public UrunIslem()
        {
            InitializeComponent();
            Urun_Grubu_Islemleri();
        }
        private void Urun_Grubu_Islemleri()
        {
            UrunGrubu ug = UrunGrubu.tum_gruplar();
            urun_grubu_listesi = new ObservableCollection<UrunGrubu>(UrunGrubu.urun_gruplari());
            urun_grubu_listesi.Add(new UrunGrubu { grup_adi = ug.grup_adi, yazici_id= ug.yazici_id, urun_turu_id= ug.urun_turu_id, vergi_id = ug.vergi_id });
            Yazici yzc = Yazici.yazicilar();
            yazici_listesi = new ObservableCollection<Yazici>(Yazici.tum_yazicilar());
            yazici_listesi.Add(new Yazici { adi = yzc.adi, id = yzc.id});
            Vergi vrg = Vergi.tum_vergileri_getir();
            vergi_listesi = new ObservableCollection<Vergi>(Vergi.tum_vergiler());
            vergi_listesi.Add(new Vergi { id = vrg.id, vergi_orani = vrg.vergi_orani });
            urunGrublariGrid.ItemsSource = urun_grubu_listesi;
            yazicilar.ItemsSource = yazici_listesi;
            vergiler.ItemsSource = vergi_listesi;
        }
    }
