    public class JobViewModel
    {
      public ObservableCollection<JobViewModel> JobsTest { get; set; }
      public ObservableCollection<JobViewModel> SelectedJobs { get; set; }
      public JobViewModel() {
        JobsTest = new ObservableCollection<JobViewModel>();
        SelectedJobs = new ObservableCollection<JobViewModel>();
      
      }
      public string Name {
        get;
        set;
      }
      public System.Collections.IList SelectedItems {
        get {
          return SelectedJobs;
        }
        set {
          SelectedJobs.Clear();
          foreach (JobViewModel model in value) {
           SelectedJobs.Add(model);
          }
        }
      }
    }
