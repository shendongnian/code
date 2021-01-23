    public class SlotCollection : IEnumerable<KeyValuePair<int, double>>
    {
        private List<Slot> _Slots;
        private double _TolerancePerSlot;
        public SlotCollection(double tolerancePerSlot)
        {
            if(tolerancePerSlot < 0)
                throw new ArgumentException("tolerancePerSlot must be greater or equal zero.", "tolerancePerSlot");
            _TolerancePerSlot = tolerancePerSlot;
            _Slots = new List<Slot>();
            Slots = new ReadOnlyCollection<Slot>(_Slots);
        }
        public ReadOnlyCollection<Slot> Slots { get; private set; }
        public void Add(IEnumerable<double> values)
        {
            foreach (var value in values)
            {
                Add(value);
            }
        }
        public IEnumerator<KeyValuePair<int, double>> GetEnumerator()
        {
            for (int i = 0; i < _Slots.Count; i++)
            {
                yield return new KeyValuePair<int, double>(i, _Slots[i].Values.First());
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private void Add(double value)
        {
            var matchingSlot = _Slots.FirstOrDefault(slot => slot.IsResponsible(value));
            if (matchingSlot == null)
            {
                matchingSlot = new Slot(value, value + _TolerancePerSlot);
                _Slots.Add(matchingSlot);
            }
            else
            {
                matchingSlot.Add(value);
            }
        }
    }
