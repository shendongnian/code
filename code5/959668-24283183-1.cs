    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        vm.NumericNotes.Add(new NumericNoteItem { Number = 1, Pitch = 0 });
        vm.NumericNotes.Add(new NumericNoteItem { Number = 2, Pitch = 1 });
        vm.NumericNotes.Add(new NumericNoteItem { Number = 3, Pitch = -1 });
        vm.NumericNotes.Add(new NumericNoteItem { Number = 4, Pitch = 0 });
        vm.NumericNotes.Add(new NumericNoteItem { Number = 5, Pitch = 2 });
        vm.NumericNotes.Add(new NumericNoteItem { Number = 6, Pitch = -2 });
        vm.NumericNotes.Add(new NumericNoteItem { Number = 4, Pitch = 0 });
        vm.NumericNotes.Add(new NumericNoteItem { Number = 5, Pitch = 3 });
        vm.NumericNotes.Add(new NumericNoteItem { Number = 6, Pitch = -3 });
        DataContext = vm;
    }
