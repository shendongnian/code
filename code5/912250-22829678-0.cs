        public Boolean SubmitProfiles(String dcmClientId, List<DcmProfile> dcmProfiles)
        {
            try
            {
                using (var dc = new JCEContext())
                {
                    // Update object graph or insert new profiles 
                    foreach (var dcmProfile in dcmProfiles)
                        dc.UpdateGraph(dcmProfile, map => map
                            .OwnedCollection(profile => profile.Plugins, with => with
                                .OwnedCollection(plugin => plugin.Counters)));
                    
                    // Get a list of profiles that no longer exists
                    var deletedProfiles = dc.DcmProfiles.Where(x => x.DcmClientId == dcmClientId).Except(dcmProfiles, x => x.Id);
                    foreach (var profile in deletedProfiles)
                        dc.DcmProfiles.Remove(profile);
                    
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
