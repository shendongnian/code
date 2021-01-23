    private IQueryable<Device> FilterCentraStageDeviceList(List<Device> centraStageDevices, string filter, string filterValue)
        {
            IQueryable<Device> alldevices = centraStageDevices.AsQueryable<Device>();
            IQueryable<Device> query = new List<Device>().AsQueryable();
            if (filter == null || string.IsNullOrEmpty(filterValue))
            {
                return alldevices;
            }
            filterValue = filterValue.ToLower();          
            var filterLower = filter.ToLower();
            if (filterLower.Contains("all") || (filterLower.Contains("hostname") && filterLower.Contains("operatingsystem") && filterLower.Contains("status") && filterLower.Contains("lastloggedinuser")))
            {
                return alldevices.Where(x => checkNull(x.Name).Contains(filterValue) || checkNull(x.OperatingSystem).Contains(filterValue) || checkNull(x.LastUser).Contains(filterValue));               
            }
            if (filterLower.Contains("hostname"))
            {
                query = alldevices.Where(x => checkNull(x.Name).Contains(filterValue));
            }
            if (filterLower.Contains("operatingsystem"))
            {
                query = alldevices.Where(x => checkNull(x.OperatingSystem).Contains(filterValue)).Union(query);
            }
            if (filterLower.Contains("lastloggedinuser"))
            {
                query = alldevices.Where(x => checkNull(x.LastUser).Contains(filterValue)).Union(query);
            }            
            return query;
        }
