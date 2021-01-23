    [StructLayout(LayoutKind.Explicit)]
    public struct CommonDenominatorBetweenColoursAndDoubles {
    	[FieldOffset(0)]
    	public byte R;
    	[FieldOffset(1)]
    	public byte G;
    	[FieldOffset(2)]
    	public byte B;
        // we renamed this field in order to avoid simple breaks in the consumer code
    	[FieldOffset(0)]
    	private double _AsDouble;
        // now, a little helper const
        private const int N_MINUS_1 = 256 * 256 * 256 - 1;
        // and maybe a precomputed raw range length
        private static readonly double RAW_RANGE_LENGTH = double.Epsilon * N_MINUS_1;
  
        // and now we're adding a property called AsDouble
        public double AsDouble {
            get { return this._AsDouble / RAW_RANGE_LENGTH; }
            set { this._AsDouble = value * RAW_RANGE_LENGTH; }
        }
    }
