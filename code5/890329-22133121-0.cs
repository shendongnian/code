    using (var context = new SADWorkshopEntities())
            {
                var query = (from p in context.user_profile
                             where p.deviceID == deviceid
                             select p).ToList();
                if (query == null || query.Count == 0)
                {
                    context.user_profile.Add(new user_profile()
                    {
                        deviceID = deviceid,
                        uri = subscriberUri
                    });
                    context.SaveChanges();
                }
