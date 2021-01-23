    public ObservableCollection<MyType> DetallePresupuesto
    {
        get {
            if (_DocumentoPresupuesto == null)
                _DocumentoPresupuesto = new ObservableCollection<MyType>(); //populate here
            return _DocumentoPresupuesto;
        }
    }
