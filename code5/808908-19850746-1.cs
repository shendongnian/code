    public partial class MainForm : Form
    {
        Process myProcess = Process.GetProcessesByName("ffxiv").FirstOrDefault();
        public MainForm()
        {
            InitializeComponent();
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            int bytesRead;
            IntPtr baseAddress = myProcess.MainModule.BaseAddress;
            Console.WriteLine("Base Address: " + baseAddress);
            IntPtr firstAddress = IntPtr.Add(baseAddress, 0xF8BEFC);
            IntPtr firstAddressValue = (IntPtr)BitConverter.ToInt32(MemoryHandler.ReadMemory(myProcess, firstAddress, 4, out bytesRead), 0);
            IntPtr finalAddr = IntPtr.Add(firstAddressValue, 0x1690);
            Console.WriteLine("Final Address: " + finalAddr.ToString("X"));
            byte[] memoryOutput = MemoryHandler.ReadMemory(myProcess, finalAddr, 4, out bytesRead);
            int value = BitConverter.ToInt32(memoryOutput, 0);
            Console.WriteLine("Read Value: " + value);
        }
    }
