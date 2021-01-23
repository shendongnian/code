    public class LimitsViewModel : PropertyChangedBase
    {
        private CancellationTokenSource tokenSource;
        public LimitsViewModel()
        {
            this.tokenSource = new CancellationTokenSource();
        }
        public ICommand LoadCommand
        {
            get { return new RelayCommand(async x => await this.LoadLimits(this.tokenSource.Token)); }
        }
        private ProductFamily selectedProduct;
        public ProductFamily SelectedProduct
        {
            get { return this.selectedProduct; }
            set
            {
                this.SetPropertyChanged(ref this.selectedProduct, value);
                this.LoadCommand.Execute(null);
            }
        }
        private ObservableCollection<BindedLimit> limits;
        public ObservableCollection<BindedLimit> Limits
        {
            get { return this.limits; }
            set { this.SetPropertyChanged(ref this.limits, value); }
        }
        private bool limitsLoading;
        public bool LimitsLoading
        {
            get { return this.limitsLoading; }
            set { this.SetPropertyChanged(ref this.limitsLoading, value); }
        }
        private BindedLimit selectedLimit;
        public BindedLimit SelectedLimit
        {
            get { return this.selectedLimit; }
            set { this.SetPropertyChanged(ref this.selectedLimit, value); }
        }
        private async Task LoadLimits(CancellationToken ct)
        {
        }
    }
