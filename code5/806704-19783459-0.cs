    var workstepid = 484,449;
    var wsData = ion.xWorkSteps
       .Where(w => w.WorkStepId == workstepId)
       .Select(w => new
       {
          w.WorkStepId.Value,
          w.ServiceId.Value,
          w.Service.TitleId.Value,
          w.Service.Title.OrderId.Value,
          w.Service.Title.AltTitleId.Value
       }).SingleOrDefault();
