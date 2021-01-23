    public class Foo
    {
        private List<FSKDevice> Devices = _db.Devices.ToList();
        private IList<ILookup<string, FSKDevice>> lookups;
            
        public Foo()
        {
            lookups = new[]{ 
                Devices.ToLookup(device => device.IPaddress1),
                Devices.ToLookup(device => device.IPaddress2),
                Devices.ToLookup(device => device.IPaddress3),
            };
        }
        public FSKDevice TryFindDeviceInNetworks(ALL_Sims sim)
        {
            var ips =  new[] { sim.IP1, sim.IP2 }
                .Where(ip => ip != null);
            return (from ip in ips
                    from lookup in lookups
                    let matches = lookup[ip]
                    where matches.Any()
                    select matches.First())
                        .FirstOrDefault();
        }
    }
