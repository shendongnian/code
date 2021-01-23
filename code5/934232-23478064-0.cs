      public class TrackActivitys: dictionary<string, TrackActivity>
      {
          public void Add(string studentName, string activityName, int activityScore)
          {
               base.Add(studentName,
                       new TrackActivity(studentName, activityName, activityScore));
          }
          public TrackActivity this[string studentName]
          {
              get { return base[studentName]; }
          }
      }
