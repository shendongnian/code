     public class ChartViewModel
            {
                    public ObservableCollection<TestClass> Errors { get; private set; }
                    public ChartViewModel()
                {
                    Errors = new ObservableCollection<TestClass>();
                    Errors.Add(new TestClass() { Category = "Globalization", Number= 75 });
                    Errors.Add(new TestClass() { Category = "Features", Number = 2 });
                    Errors.Add(new TestClass() { Category = "ContentTypes", Number = 12 });
                    Errors.Add(new TestClass() { Category = "Correctness", Number = 83 });
                    Errors.Add(new TestClass() { Category = "Best Practices", Number = 29 });
                }
        
                private object selectedItem = null;
                public object SelectedItem
                {
                    get
                    {
                        return selectedItem;
                    }
                    set
                    {
                        selectedItem = value;
                    }
                }
            }
