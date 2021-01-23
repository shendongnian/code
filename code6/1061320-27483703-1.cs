    public ObservableCollection<MyType> DetallePresupuesto
    {
        get {
            if (_DetallePresupuesto == null)
                _DetallePresupuesto = new ObservableCollection<MyType>(); //populate here
            return _DetallePresupuesto;
        }
    }
