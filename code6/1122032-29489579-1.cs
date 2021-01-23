    public class BindableBit : INotifyPropertyChanged {
            private int bit;
            private readonly int index;
            public Action<int, int> ChangedAction;
            public int Value {
                get { return bit; }
                set {
                    bit = value;
                    OnPropertyChanged();
                    if (ChangedAction != null) ChangedAction(index, bit);
                }
            }
            public BindableBit(int index) {
                this.index = index;
            }
            ...PropertyChangedImplementation
        }
