    public class DashboardService : SecureService
    {
        private readonly DashboardAdapter _dashboardAdapter;
        public DashboardService(DashboardAdapter dashboardAdapter)
        {
            _dashboardAdapter = dashboardAdapter;
        }
        public object Get(DashboardRequest request)
        {
            return new Dashboard { IsConnected = _dashboardAdapter.IsConnected };
        }
    }
