    using System.Runtime.InteropServices;
    using Microsoft.VisualBasic.Devices;
    public class MemStat
    {
        public ulong Available { get; set; }
        public ulong Total { get; set; }
        public ulong PhysicalMemoryInUse { get; set; }
        public ulong Free { get; set; }
        public ulong Cached { get; set; }
        public MemStat()
        {
            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            var Available = new ComputerInfo().AvailablePhysicalMemory;
            this.Available = Available;
            var Total = new ComputerInfo().TotalPhysicalMemory;
            this.Total = Total;
            var PhysicalMemoryInUse = Total - Available;
            this.PhysicalMemoryInUse = PhysicalMemoryInUse;
            Object Free = new object();
            foreach (var result in results)
            {
                Free = result["FreePhysicalMemory"];
                this.Free = ulong.Parse(Free.ToString());
            }
            var Cached = Total - PhysicalMemoryInUse - ulong.Parse(Free.ToString());
            this.Cached = Cached;
        }
