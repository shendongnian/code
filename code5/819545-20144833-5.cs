    public class ProjectAndUserOverView
    {
        public ProjectOverviewViewModel ProjectOverview {get;set;}
        public ProjectUsersViewModel ProjectUsers {get;set;}
        // Code here to listen for property changes in ProjectOverview and if SelectedProject changes
        // call ProjectUsersViewModel to refresh the data for the selected user
    }
