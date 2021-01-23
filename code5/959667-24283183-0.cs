    public class NumericNoteItem
    {
        public int Number { get; set; }
        public int Pitch { get; set; }
    }
    public class ViewModel
    {
        public ViewModel()
        {
            NumericNotes = new ObservableCollection<NumericNoteItem>();
        }
        public ObservableCollection<NumericNoteItem> NumericNotes { get; private set; }
    }
