    public Device TryFindDeviceInNetworks(ALL_Sims sim)
    {
        Device device = null;
        if (sim.IP1 != null)
        {
            if (mapIP1.TryGetValue(sim.IP1, out device))
                return device;
            if (mapIP2.TryGetValue(sim.IP1, out device))
                return device;
            if (mapIP3.TryGetValue(sim.IP1, out device))
                return device;
        }
        if (sim.IP2 != null)
        {
            if (mapIP1.TryGetValue(sim.IP2, out device))
                return device;
            if (mapIP2.TryGetValue(sim.IP2, out device))
                return device;
            if (mapIP3.TryGetValue(sim.IP2, out device))
                return device;
        }
        return device;
    }
