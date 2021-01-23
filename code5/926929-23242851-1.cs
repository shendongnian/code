    public class Clinician
    {
      public int ClinicianId { get; set; }
      public virtual ICollection<CarePeriod> CarePeriods { get; set; }
      ...
    }
    public class Client
    {
      public int ClientId { get; set; }
      public virtual ICollection<CarePeriod> CarePeriods { get; set }
      ...
    }
    public class CarePeriod
    {
      public int CarePeriodId { get; set; }
      public int ClinicianId { get; set; }
      public virtual Clinician Clinician { get; set; }
      public int ClientId { get; set; }
      public virtual Client Client { get; set; }
      ...
    }
