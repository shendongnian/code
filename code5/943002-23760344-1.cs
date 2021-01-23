    foreach (ObjectStateEntry entry in objectStateEntryList)
    {
        IClub club = entry.Entity as IClub;
        if (!entry.IsRelationship && club!=null)
        {
              newClubPrimaryKeyId = club.GetClubId();
              ...
        }
    }
