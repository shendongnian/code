        public String tableall                      // UP TO 400 OCCURS
        {
            get { return getString(0, 29750); }
            set { setString(0, 29750, value); }
        }
        public StringArray tableoc1                 // INDEXED REDEFINE OF ABOVE
        {
            get { return getStringArray(0, 85, 350, 85); }
            set { setStringArray(0, 85, 350, 85, value); }
        }
        public String tablescreen                   // UP TO 400 OCCURS
        {
            get { return getString(29750, 1275); }
            set { setString(29750, 1275, value); }
        }
        public StringArray tablescr                 // INDEXED REDEFINE OF ABOVE
        {
            get { return getStringArray(29750, 85, 15, 85); }
            set { setStringArray(29750, 85, 15, 85, value); }
        }
        public StringArray duedates
        {
            get { return getStringArray(29750, 10, 15, 85); }
            set { setStringArray(29750, 10, 15, 85, value); }
        }
        public StringArray accts
        {
            get { return getStringArray(29760, 6, 15, 85); }
            set { setStringArray(29760, 6, 15, 85, value); }
        }
        public DecimalArray taxs
        {
            get { return getDecimalArray(29766, 9, 2, 15, 85); }
            set { setDecimalArray(29766, 9, 2, 15, 85, value); }
        }
        public DecimalArray penaltys
        {
            get { return getDecimalArray(29775, 9, 2, 15, 85); }
            set { setDecimalArray(29775, 9, 2, 15, 85, value); }
        }
        public DecimalArray interests
        {
            get { return getDecimalArray(29784, 9, 2, 15, 85); }
            set { setDecimalArray(29784, 9, 2, 15, 85, value); }
        }
        public DecimalArray feess
        {
            get { return getDecimalArray(29793, 9, 2, 15, 85); }
            set { setDecimalArray(29793, 9, 2, 15, 85, value); }
        }
        public DecimalArray totalpaids
        {
            get { return getDecimalArray(29802, 13, 2, 15, 85); }
            set { setDecimalArray(29802, 13, 2, 15, 85, value); }
        }
        public BinaryArray seqnums
        {
            get { return getBinaryArray(29815, 2, 15, 85); }
            set { setBinaryArray(29815, 2, 15, 85, value); }
        }
        public StringArray billnums
        {
            get { return getStringArray(29817, 8, 15, 85); }
            set { setStringArray(29817, 8, 15, 85, value); }
        }
        public StringArray fileddates
        {
            get { return getStringArray(29825, 10, 15, 85); }
            set { setStringArray(29825, 10, 15, 85, value); }
        }
        public String tableoc2                      // ONE OCCUR OF DATA
        {
            get { return getString(31025, 85); }
            set { setString(31025, 85, value); }
        }
        public String duedatex
        {
            get { return getString(31025, 10); }
            set { setString(31025, 10, value); }
        }
        public String acctx
        {
            get { return getString(31035, 6); }
            set { setString(31035, 6, value); }
        }
        public Decimal taxx
        {
            get { return getDecimal(31041, 9, 2); }
            set { setDecimal(31041, 9, 2, value); }
        }
        public Decimal penaltyx
        {
            get { return getDecimal(31050, 9, 2); }
            set { setDecimal(31050, 9, 2, value); }
        }
        public Decimal interestx
        {
            get { return getDecimal(31059, 9, 2); }
            set { setDecimal(31059, 9, 2, value); }
        }
        public Decimal feesx
        {
            get { return getDecimal(31068, 9, 2); }
            set { setDecimal(31068, 9, 2, value); }
        }
        public Decimal totalpaidx
        {
            get { return getDecimal(31077, 13, 2); }
            set { setDecimal(31077, 13, 2, value); }
        }
        public int seqnumx
        {
            get { return getBinary(31090, 2); }
            set { setBinary(31090, 2, value); }
        }
        public String billnumx
        {
            get { return getString(31092, 8); }
            set { setString(31092, 8, value); }
        }
        public String fileddatex
        {
            get { return getString(31100, 10); }
            set { setString(31100, 10, value); }
        }
    }
	
	public StringArray getStringArray(int i)
        {
            return getStringArray(getOffSet(i, ColumnSize[i]), ColumnSize[i], ArrayLength, 0, i);
        }
		
	public class StringArray : AnyArray
        {
            public String this[int i]
            {
                get { return rec.getString(offset + disp * (i - 1), len); }
                set { rec.setString(offset + disp * (i - 1), len, value); }
            }
            public StringArray(basicRecord rec, int offset, int len, int ArrayLen, int Disp = 0, int ColumnNo = 0)
                : base(rec, offset, len, ArrayLen, Disp, ColumnNo)
            {
                //do nothing. Basclass constructor handles this
            }
            public bool Find(string compare)
            {
                for (int i = 1; i <= arrayLen + 1; i++)
                {
                    if (this[i].Trim() == compare.Trim())
                        return true;
                }
                return false;
            }
        }
		
		public class AnyArray
        {
            protected int offset;
            protected int len;
            protected int arrayLen;
            protected int disp;
            protected basicRecord rec;
            public int columnNo;
            public AnyArray()
            {
            }
            public AnyArray(basicRecord rec, int offset, int len, int ArrayLen, int Disp = 0, int ColumnNo = 0)
            {
                this.rec = rec;
                this.offset = offset;
                this.len = len;
                this.arrayLen = ArrayLen;
                this.disp = (Disp == 0) ? len : Disp;
                this.columnNo = ColumnNo;
            }
        }
