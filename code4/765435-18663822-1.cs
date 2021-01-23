    public void UpdateModel() {
        this.OperatingPoints.Clear();
        foreach ( Operating_Point point in new OperatingPointRepository().GetAll() ) {
            this.OperatingPoints.Add(point);
        }
        NotifyPropertyChanged( "OperatingPoints" );
    }
