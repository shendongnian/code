    using System;
    using AutoMapper;
    public class Job {
      public string Prefix { get; set; }
      public int JobNumber { get; set; }
      public int Year { get; set; }
      public int JobPriority { get; set; }
      public virtual EntityPriority EntityPriority { get; set; }
    }
    public class JobViewModel {
      public string JobNumberFull { get; set; }
    }
    public enum EntityPriority {
      Normal = 0,
      High
    }
    class Program {
      static void Main(string[] args) {
        Mapper.CreateMap<Job, JobViewModel>().ConvertUsing(
          job => new JobViewModel {
            JobNumberFull = string.Format("{0}-{1}-{2}", job.Prefix, job.JobNumber, job.Year)
          });
        Job j = new Job() {
          JobNumber = 1,
          Prefix = "prefix",
          Year = 2013,
          EntityPriority = EntityPriority.High,
          JobPriority = 2
        };
        var model = Mapper.Map<JobViewModel>(j);
        Console.WriteLine(model.JobNumberFull);
      }
    }
