    public ActionResult Edit(List<TimeRecord> timeRecords);
    {
      // Sort by start time and group by job number
      var jobRecords = timeRecords.OrderBy(r => r.StartDateTime).GroupBy(r => r.JobID);
      // enumerate each group
      foreach (var group in jobRecords)
      {
        // enumerate each record in the group
        foreach (var record in group)
        {
          if (group.Any(r => r.StartDateTime >= record.StartDateTime && r.StartDateTime < record.EndDateTime))
          {
            // we have overlapping records?
          }
        }
      }
    }
