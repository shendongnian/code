	public class Device {
		public int HardwareId { get; set; }
		public Device[] Children {get; set; }
		/* ...the rest... */
	}								
	void DisplayNodes(IEnumerable<Device> currentCollection, int indentation) {
		foreach (var currentNode in currentCollection) {
			// Display current node
			Console.WriteLine(
                ...
                display the node and
                use the indentation parameter to control the --- or ---|---
                ...
            );
			
			if (currentNode.Children != null) {
				DisplayNode(currentNode.Children, indentation + 1);
			}
		}
	}
	// Data
	IEnumerable<Device> allDevices = usbDeviceTree.USBDeviceNodes;
	IEnumerable<Device> rootDevices = allDevices
        .Where(x => x.IsRootNode /* TODO */)
        .ToArray();
	// Display
	DisplayNodes(rootDevices, 1);
