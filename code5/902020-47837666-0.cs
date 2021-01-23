            var cratelist = db.TruckContainerLoads.Where(x => x.TruckID == truckid).Select(x => x.ContainerID);
            if (!cratelist.Any())
            {
                return;
            }
            foreach (var crateid in cratelist) {
                TruckContainerLoad crInstance = new TruckContainerLoad();
                crInstance.ContainerID = crateid;
                try
                {
                    db.TruckContainerLoads.Add(crInstance);
                    db.SaveChanges();
                }
                catch
                {
                    return;
                }
            }
