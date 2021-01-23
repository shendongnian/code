    public Boolean SubmitProfiles(String dcmClientId, List<DcmProfile> dcmProfiles)
    {
    
        try
        {
    
            using (var dc = new JCEContext())
            {
                var existing = dc.DcmProfiles.AsNoTracking().Where(x => x.DcmClientId == dcmClientId).ToList();
                var added = dcmProfiles.Except(existing, x => x.Id).ToList();
                var deleted = existing.Except(dcmProfiles, x => x.Id).ToList();
                var modified = dcmProfiles.Except(added, x => x.Id);
                     
                // Update modified profiles
                foreach (var dcmProfile in modified)
                    dc.UpdateGraph(dcmProfile, map => map
                        .OwnedCollection(profile => profile.Plugins, with => with
                            .OwnedCollection(plugin => plugin.Counters)));
    
                // Add new profiles
                added.ForEach(profile => dc.Entry(profile).State = EntityState.Added);
    
                // Delete nonexistent profiles
                deleted.ForEach(profile => dc.Entry(profile).State = EntityState.Deleted);
    
                dc.SaveChanges();
    
            }
    
            return true;
    
        }
        catch (Exception ex)
        {
            Log.ErrorException(ex.Message, ex);
            return false;
        }
    
    }
