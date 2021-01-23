    public partial class SchedulerListItemDetails : UserControl
    {
        public SchedulerListItemDetails()
        {
            InitializeComponent();
        }
        public SchedulerListItemDetails(SchedulerListItem item, Form owner)
        {
            InitializeComponent();
            this.SourcePath = item.SourcePath;
            ...
        }
    }
