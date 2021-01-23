    var workstepid = 484,449;
    
    var wsData = ion.xWorkSteps
       .Where(w => w.WorkStepId == workstepId)
       .Select(w => new
       {
         WorkStepId = (int?)w.WorkStepId,
         ServiceId = (int?)w.ServiceId,
         TitleId = (int?)w.Service.TitleId,
         OrderId = (int?)w.Service.Title.OrderId,
         w.Service.Title.AltTitleId
       }).SingleOrDefault();
