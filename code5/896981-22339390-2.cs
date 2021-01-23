    private Model _model;
    public Model Model {
        get {
            if (_model == null) {
                _model = new Model();
            }
            return _model;
        }
    }
    public MainWindow() {
        InitializeComponent();
        this.DataContext = this.Model;
        this.Model.Countries.Add(new Country("UK", "London"));
        this.Model.Countries.Add(new Country("Ireland", "Dublin"));
        this.Model.Countries.Add(new Country("France", "Paris"));
        this.Model.Countries.Add(new Country("USA", "Washington D. C."));
        this.Model.Countries.Add(new Country("Mexico", "Mexico City"));
        this.Model.Countries.Add(new Country("Canada", "Ottawa"));
    }
