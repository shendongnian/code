    public partial class TicketDetailControl : UserControl
    {
        private Ticket info = null;
        public TicketDetailControl()
        {
            InitializeComponent();
        }
        public Ticket Info
        {
            get { return info; }
            set
            {
                info = value;
                Description.Text = info.Description.ToString();
                Status.ItemsSource = AutoTaskData.StatusIdByName;
                Status.SelectedValue = info.Status.ToString();
                Queue.ItemsSource = AutoTaskData.QueueIdByName;
                Queue.SelectedValue = info.QueueID.ToString();
                IssueType.ItemsSource = AutoTaskData.IssueType;
                IssueType.SelectedValue = info.IssueType.ToString();
                CurrentSub.Clear();
                SubIssueType.ItemsSource = null;
                foreach (var item in AutoTaskData.Subs.Where(item => item.Item1 == (string)IssueType.SelectedValue))
                {
                    CurrentSub.Add(item.Item2, item.Item3);
                }
                SubIssueType.ItemsSource = CurrentSub;
                SubIssueType.SelectedValue = info.SubIssueType.ToString();
            }
        }
        private Dictionary<string, string> CurrentSub = new Dictionary<string, string>(); 
        private void IssueType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentSub.Clear();
            SubIssueType.ItemsSource = null;
            foreach (var item in AutoTaskData.Subs.Where(item => item.Item1 == (string) IssueType.SelectedValue))
            {
                CurrentSub.Add(item.Item2, item.Item3);
            }
            SubIssueType.ItemsSource = CurrentSub;
          
        }
    }
    
