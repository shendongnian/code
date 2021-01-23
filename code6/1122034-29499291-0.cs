    [ContentProperty("BitByte")]
    public partial class BitManipulator : UserControl,
        INotifyPropertyChanged
    {
        public BitManipulator()
        {
            InitializeComponent();
            this.grid_Items.DataContext = this;
        }
        #region Indexer and related
        public Boolean this[Int32 index]
        {
            get
            {
                return BitConverterExt.BitAt(this.BitByte, index);
            }
            set
            {
                this.BitByte = BitConverterExt.WithSetBitAt(this.BitByte, index, value);
            }
        }
        
        #endregion
        
        #region Dependency properties
        public static DependencyProperty BitByteProperty =
            DependencyProperty.Register
            (
                "BitByte",
                typeof(Byte),
                typeof(BitManipulator),
                new PropertyMetadata((sender, args) =>
                    {
                        if (args.Property != BitByteProperty)
                            return;
                        if (args.NewValue == args.OldValue)
                            return;
                        
                        var This = (BitManipulator)sender;
                        This.OnPropertyChanged("Item[]");
                    })
            );
        public Byte BitByte
        {
            get { return (Byte)GetValue(BitByteProperty); }
            set { SetValue(BitByteProperty, value); }
        }
        #endregion
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged(this,
                new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
