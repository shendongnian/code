    public interface IMemory
    {
        void Write(int address, params byte[] bytes);
        byte[] Read(int address, int numBytes);
        byte Read(int address);
        event MemoryChangedEventHandler MemoryChanged;
    }
    public class Memory : IMemory
    {
        private readonly byte[] _memory;
        public Memory(int size)
        {
            _memory = new byte[size];
        }
        public void Write(int address, params byte[] bytes)
        {
            for (int offset = 0; offset < bytes.Length; offset++)
            {
                _memory[address + offset] = bytes[offset];
            }
            UpdateMemory(address, bytes.Length);
        }
        public byte[] Read(int address, int numBytes)
        {
            return _memory.Skip(address).Take(numBytes).ToArray();
        }
        public byte Read(int address)
        {
            return _memory[address];
        }
        private void UpdateMemory(int address, int length)
        {
            if (MemoryChanged != null)
            {
                MemoryChanged(this, new MemoryChangedEventArgs
                {
                    StartAddress = address,
                    EndAddress = address + length
                });
            }
        }
        public event MemoryChangedEventHandler MemoryChanged;
    }
    public delegate void MemoryChangedEventHandler(object sender, MemoryChangedEventArgs e);
    public class MemoryChangedEventArgs
    {
        public int StartAddress { get; set; }
        public int EndAddress { get; set; }
    }
    public class IntVariable : INotifyPropertyChanged
    {
        private readonly int _address;
        private readonly Memory _memory;
        public IntVariable(int address, Memory memory)
        {
            _address = address;
            _memory = memory;
            _memory.MemoryChanged += MemoryChanged;
        }
        private void MemoryChanged(object sender, MemoryChangedEventArgs e)
        {
            int startAddress = _address;
            int endAddress = startAddress + sizeof (int);
            int changedStartAddress = e.StartAddress;
            int changedEndAddress = e.EndAddress;
            if (IsVariableChanged(startAddress, changedStartAddress, endAddress, changedEndAddress))
            {
                OnPropertyChanged("Value");
            }
        }
        private static bool IsVariableChanged(int startAddress, int changedStartAddress, int endAddress, int changedEndAddress)
        {
            return Math.Max(startAddress, changedStartAddress) <= Math.Min(endAddress, changedEndAddress);
        }
        public int Value
        {
            get
            {
                var intBytes = _memory.Read(_address, sizeof(int));
                return BitConverter.ToInt32(intBytes, 0);
            }
            set
            {
                var intBytes = BitConverter.GetBytes(value);
                _memory.Write(_address, intBytes);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
