    public partial class Trainer
    {
      [Search("PersonalData", true)]
      public virtual PersonalData PersonalData { get; set; }
      [Search("Subject", true)]
      public virtual ICollection<Subject> Subjects { get; set; }
    }
