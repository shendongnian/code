    public class ProjectViewModel
    {
        // Either put the actual data item in here and wrap it:
        public Project Project {get;set;}
        // Or copy properties onto the viewmodel using automapper or some other mapping framework...
        // or manually :(
        // e.g. properties mirrored from the entity object:
        public int ProjectId { get;set;}
        public string ProjectName { get;set;}
        // The selected property - now your 'Selected' logic is a function of the view/viewmodel
        // not the entity. The entity should only be concerned with data persistence
        public bool IsSelected {get;set;}
    }
