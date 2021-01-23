    public class ApplicantApplicationRecordingsViewModel
    {
      public Applicant Applicant { get; set; }
      public Application Application { get; set; }
      public IEnumerable<RecordingViewModelApp> Recordings { get; set; }
      public string Title { get; set; }
      public SelectList UsageTypeSelectList { get; private set; }
      public SelectList UsageEndAppSelectList { get; private set; }
    }
