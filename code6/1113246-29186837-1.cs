    public ObservableCollection<MarcaViewModel> GetMarcas()
    {
        Marcas.Clear();
        using (var db = new SQLite.SQLiteConnection(App.DBPath))
        {
            var query = db.Table<Marcas>();
            foreach (var _mrc in query)
            {
                var mrc = new MarcaViewModel()
                {
                    idMarca  = _mrc.idMarca ,
                    marca  = _mrc.marca                         
                };
                Marcas.Add(mrc);
            }
        }
        return marcas;
    }
