    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace TestConsoleApp
    {
    class Program
    {
        static void Main(string[] args) {
            DeviceStatus deviceA = new DeviceStatus() { DeviceName = "A", DeviceType = "foo" };
            DeviceStatus deviceB = new DeviceStatus() { DeviceName = "B", DeviceType = "bar" };
            DeviceStatus deviceC = new DeviceStatus() { DeviceName = "C", DeviceType = "foo" };
            DeviceStatus deviceD = new DeviceStatus() { DeviceName = "D", DeviceType = "zed" };
            MachineStatus status1 = new MachineStatus() { MachineName = "1", Department = "1", LocationName = "1", Devices = new List<DeviceStatus>{ deviceA, deviceB} };
            MachineStatus status2 = new MachineStatus() { MachineName = "2", Department = "2", LocationName = "2", Devices = new List<DeviceStatus> { deviceC, deviceD } };
            List<MachineStatus> machines = new List<MachineStatus>() { status1, status2};
            var result = machines.SelectMany(x => x.Devices, (a, b) => new { DeviceType = b.DeviceType, MachineName = a.MachineName, DeviceName = b.DeviceName } );
            var result2 = result.GroupBy(x => new {x.DeviceType}).Select( z => new { DeviceType = z.Key.DeviceType, Machines = z.ToList().GroupBy(y => y.MachineName) });
            foreach (var group1 in result2)
            {
                foreach (var group2 in group1.Machines)
                {
                    foreach (var group3 in group2)
                    {
                        Console.Write(group1.DeviceType + ":");
                        Console.Write(group3.MachineName + ":");
                        Console.WriteLine(group3.DeviceName);
                    }
                }
            }
            Console.ReadLine();
        }
        public class MachineStatus
        {
            public string MachineName { get; set; }
            public string Department { get; set; }
            public string LocationName { get; set; }
            public IEnumerable<DeviceStatus> Devices { get; set; }
        }
        public class DeviceStatus
        {
            public string DeviceName { get; set; }
            public string DeviceType { get; set; }
            public string IpAddress { get; set; }
            public ConnectionStatus Status { get; set; }
        }
        public class ConnectionStatus
        {
        }
    }
    }
