    List<UserProfile> GetProfiles()
        {
            using (MusicOwnerDatabaseEntities context = new MusicOwnerDatabaseEntities())
            {
                return context.UserProfileSet.ToList();
            }
        }
