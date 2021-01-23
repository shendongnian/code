    public partial class MainWindow : Window
    {
        public class CheckboxData
        {
            public int Id { get; set; }
            public string Label { get; set; }
            public bool Checked { get; set; }
        }
        public MainWindow()
        {
            DataContext = this;
            for (int i = 0; i < 50; i++)
                Checkboxes.Add(new CheckboxData { Id = i, Label = $"Checkbox {i}" });
        }
        public IList<CheckboxData> Checkboxes { get; set; } = new List<CheckboxData>();
    }
