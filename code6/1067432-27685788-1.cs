    [DllImport("kernel32.dll")]
    static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
    
    [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
    static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
    
    [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
    static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
    
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);
    
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesRead);
    
    [DllImport("kernel32.dll")]
    public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint dwFreeType);
    
    // privileges
    const int PROCESS_CREATE_THREAD = 0x0002;
    const int PROCESS_QUERY_INFORMATION = 0x0400;
    const int PROCESS_VM_OPERATION = 0x0008;
    const int PROCESS_VM_WRITE = 0x0020;
    const int PROCESS_VM_READ = 0x0010;
    
    // used for memory allocation
    const uint MEM_COMMIT = 0x00001000;
    const int MEM_DECOMMIT = 0x4000;
    const uint MEM_RESERVE = 0x00002000;
    const uint PAGE_READWRITE = 4;
    
    ///<summary>Retries the tree node information.</summary>
    ///<param name="hwndItem">Handle to a tree node item.</param>
    ///<param name="hwndTreeView">Handle to a tree view control.</param>
    ///<param name="process">Process hosting the tree view control.</param>
    private static NodeData AllocTest(Process process, IntPtr hwndTreeView, IntPtr hwndItem) {
    	// code based on article posted here: http://www.codingvision.net/miscellaneous/c-inject-a-dll-into-a-process-w-createremotethread
    
    	// handle of the process with the required privileges
    	IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, process.Id);
    
    	// Write TVITEM to memory
    	// Invoke TVM_GETITEM
    	// Read TVITEM from memory
    
    	var item = new TVITEMEX();
    	item.hItem = hwndItem;
    	item.mask = (int) (TVIF.TVIF_HANDLE | TVIF.TVIF_CHILDREN | TVIF.TVIF_TEXT);
    	item.cchTextMax = 1024;
    	item.pszText = VirtualAllocEx(procHandle, IntPtr.Zero, (uint) item.cchTextMax, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE); // node text pointer
    
    	byte[] data = getBytes(item);
    
    	uint dwSize = (uint) data.Length;
    	IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, dwSize, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE); // TVITEM pointer
    
    	uint nSize = dwSize;
    	UIntPtr bytesWritten;
    	bool successWrite = WriteProcessMemory(procHandle, allocMemAddress, data, nSize, out bytesWritten);
    
    	var sm = SendMessage(hwndTreeView, (int) TVM.TVM_GETITEM, IntPtr.Zero, allocMemAddress);
    
    	UIntPtr bytesRead;
    	bool successRead = ReadProcessMemory(procHandle, allocMemAddress, data, nSize, out bytesRead);
    
    	UIntPtr bytesReadText;
    	byte[] nodeText = new byte[item.cchTextMax];
    	bool successReadText = ReadProcessMemory(procHandle, item.pszText, nodeText, (uint) item.cchTextMax, out bytesReadText);
    
    	bool success1 = VirtualFreeEx(procHandle, allocMemAddress, dwSize, MEM_DECOMMIT);
    	bool success2 = VirtualFreeEx(procHandle, item.pszText, (uint) item.cchTextMax, MEM_DECOMMIT);
    
    	var item2 = fromBytes<TVITEMEX>(data);
    
    	String name = Encoding.Unicode.GetString(nodeText);
    	int x = name.IndexOf('\0');
    	if (x >= 0)
    		name = name.Substring(0, x);
    
    	NodeData node = new NodeData();
    	node.Text = name;
    	node.HasChildren = (item2.cChildren == 1);
    
    	return node;
    }
    
    public class NodeData {
    	public String Text { get; set; }
    	public bool HasChildren { get; set; }
    }
    
    private static byte[] getBytes(Object item) {
    	int size = Marshal.SizeOf(item);
    	byte[] arr = new byte[size];
    	IntPtr ptr = Marshal.AllocHGlobal(size);
    
    	Marshal.StructureToPtr(item, ptr, true);
    	Marshal.Copy(ptr, arr, 0, size);
    	Marshal.FreeHGlobal(ptr);
    
    	return arr;
    }
    
    private static T fromBytes<T>(byte[] arr) {
    	T item = default(T);
    	int size = Marshal.SizeOf(item);
    	IntPtr ptr = Marshal.AllocHGlobal(size);
    	Marshal.Copy(arr, 0, ptr, size);
    	item = (T) Marshal.PtrToStructure(ptr, typeof(T));
    	Marshal.FreeHGlobal(ptr);
    	return item;
    }
