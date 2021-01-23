    public List<GSMData> GetGSMList()
            {
                return meters.Where(x=>x.Gsmdata.Any()).Select(x => x.Gsmdata.Last())
                             .ToList();
            }
