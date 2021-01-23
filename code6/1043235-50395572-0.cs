    public class AutoExpandXamDataGridRecordBehavior : Behavior<XamDataGrid>
    {
        protected override void OnAttached()
        {
            if (AssociatedObject is XamDataGrid grid)
            {
                grid.InitializeRecord += OnInitializeRecord;
            }
        }
    
    
        protected override void OnDetaching()
        {
            if (AssociatedObject is XamDataGrid grid)
            {
                grid.InitializeRecord -= OnInitializeRecord;
            }
        }
    
    
        private void OnInitializeRecord(object sender, InitializeRecordEventArgs e)
        {
            ((XamDataGrid)sender).ExecuteCommand(DataPresenterCommands.ToggleRecordIsExpanded, e.Record);
        }
    }
