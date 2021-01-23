    public class NumberRange
    {
        public int First;
        public int Last;
        public NumberRange()
        {
        }
        public NumberRange(int first, int last)
        {
            First = first;
            Last = last;
        }
    }
    public class NumberRangeCollection : Collection<NumberRange>
    {
        public NumberRange BigRange = new NumberRange(3, 6);
        public NumberRange Range1 = new NumberRange(3, 4);
        public NumberRange Range2 = new NumberRange(4, 5);
        public NumberRange Range3 = new NumberRange(5, 6);
        protected override void InsertItem(int index, NumberRange item)
        {
            NumberRange[] existingItem = this.Where(x => ((x.Last < item.First) == (x.First > item.Last))).ToArray();
            if (existingItem.Any()) throw new ArgumentException("New range collides with an existing range.", "item");
            base.InsertItem(index, item);
        }
        public NumberRangeCollection RunTest1()
        {
            Clear();
            Add(Range1);
            Add(BigRange);
            return this;
        }
        public NumberRangeCollection RunTest2()
        {
            Clear();
            Add(Range2);
            Add(BigRange);
            return this;
        }
        public NumberRangeCollection RunTest3()
        {
            Clear();
            Add(Range3);
            Add(BigRange);
            return this;
        }
        public NumberRangeCollection RunTest4()
        {
            Clear();
            Add(BigRange);
            try
            {
                Add(Range1);
            }
            catch
            {
            }
            try
            {
                Add(Range2);
            }
            catch
            {
            }
            try
            {
                Add(Range3);
            }
            catch
            {
            }
            return this;
        }
    }
