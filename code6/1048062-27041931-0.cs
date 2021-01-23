    public partial class SchedulerListItemDetails : UserControl
    {
        public SchedulerListItemDetails()
        {
            InitializeComponent();
        }
        public SchedulerListItemDetails(SchedulerListItem item, Form owner): this()
        {
            this.SourcePath = item.SourcePath;
            ...
        }
    }
