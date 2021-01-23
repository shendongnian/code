        var wsData = ion.xWorkSteps
       .Where(w => w.WorkStepId == workstepId)
       .Select(w => new
       {
           w.WorkStepId,
           w.ServiceId,
           w.Service.TitleId,
           w.Service.Title.OrderId,
           w.Service.Title.AltTitleId
       })
       .Take(1)
       .ToArray();
