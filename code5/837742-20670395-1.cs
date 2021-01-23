        public sealed partial class HomePageAdmin : RESTAPHandler
    {
        private Grid visibleGrid;
        private SDSummaries _sdSummaries = new SDSummaries();
        public SDSummaries SDSummaries { get { return this._sdSummaries; } }
        public HomePageAdmin() : base()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.sd_source.Source = this.SDSummaries;
            base.OnNavigatedTo(e);
        }
        private void phoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.Address = this.NavigationContext.QueryString["URL"];
        }
        private void TicketsStatsResponse (TicketsStatsResponse response)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                PlainTitleDisclosureCellItem cell = (PlainTitleDisclosureCellItem)this.SDSummaries[1];
                cell.Label = response.NewTicketCount.ToString();
                cell = (PlainTitleDisclosureCellItem)this.SDSummaries[2];
                cell.Label = response.UnassignedTicketCount.ToString();
            });
        }
