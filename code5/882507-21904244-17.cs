    class WorkstationListForm : Form
    {
        private IEnumerable<Workstation> workstations;
        public WorkstationListForm(IEnumerable<Workstation> workstations)
        {
            this.workstations = workstations;
            //TODO: You can now use 'workstations' as the ItemsSource of a list view in this form.
        }
    }
