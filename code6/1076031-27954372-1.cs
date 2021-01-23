    using (TheContext db = new TheContext())
    {
        List<Computer> compQuery = (from compTrack in db.compTracking
                                   where compTrack.AssetActionId == 1  // or compTrack.AssetAction.ID presumably
                                   select compTrack.Computer).ToList();
    }
