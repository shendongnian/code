    public partial class MyCustomBitsControl: UserControl, INotifyPropertyChanged {
        private byte myByte;
        private readonly List<BindableBit> collection;
        public List<BindableBit> Bits {
            get { return collection; }
        }
        public MyCustomBitsControl() {
            const byte defaultValue = 7;
            myByte = defaultValue;
            var index = 0;
            collection = new BitArray(new[] { myByte }).Cast<bool>()
                .Select(b => new BindableBit(index++) { Value = (b ? 1 : 0), ChangedAction = ChangedAction }).Reverse().ToList();
            DataContext = this;
        }
        private void ChangedAction(int index, int value) {
            var bit = (byte)Math.Pow(2, index);
            if (value == 0) {
                myByte &= (byte)(byte.MaxValue - bit);
            }
            else {
                myByte |= bit;
            }
        }
        ...PropertyChangedImplementation
        }
