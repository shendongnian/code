	(using System.IO, System.Management, System.Linq, System.Collections.Generic...)
	class HardDrive
	{
		public string DiskIndex { get; set; }
		public string Model { get; set; }
		public string Type { get; set; }
		public string SerialNo { get; set; }
	}
	class Partition
	{
		public string PartitionIndex { get; set; }
		public HardDrive HardDrive { get; set; }
	}
	class LogicalDrive
	{
		public string Name { get; set; }
		public Partition Partition { get; set; }
	}
	// ... (class/method declaration etc)
	var results = new List<LogicalDrive>();
	var logicalDrives = DriveInfo.GetDrives().Where(x => x.IsReady);
	var partitions = new Dictionary<string, Partition>();
	var hardDrives = new Dictionary<string, HardDrive>();
	var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
	foreach (ManagementObject mo in searcher.Get())
	{
		var hd = new HardDrive();
		hd.Model = mo["Model"].ToString();
		hd.Type = mo["InterfaceType"].ToString();
		hd.SerialNo = mo["SerialNumber"].ToString().Trim();
		hd.DiskIndex = mo["Index"].ToString().Trim();
		hardDrives.Add(hd.DiskIndex, hd);
	}
	foreach (var logicalDrive in logicalDrives)
	{
		var res = new LogicalDrive { Name = logicalDrive.Name };
		results.Add(res);
		var driveName = logicalDrive.Name.Trim('\\');
		var queryString = String.Format("ASSOCIATORS OF {{Win32_LogicalDisk.DeviceID='{0}'}} WHERE ResultClass=Win32_DiskPartition", 
					driveName);
		searcher = new ManagementObjectSearcher(queryString);
		foreach (ManagementObject mo in searcher.Get())
		{
			var partitionIndex = mo["Index"].ToString().Trim();
			var diskIndex = mo["DiskIndex"].ToString().Trim();
			var key = partitionIndex + "-" + diskIndex;
			Partition p;
			if (!partitions.TryGetValue(key, out p))
			{
				p = new Partition
				{
					PartitionIndex = partitionIndex,
					HardDrive = hardDrives[diskIndex]
				};
				partitions.Add(key, p);
			}
			res.Partition = p;
		}
	}
