    public class CustomObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ...
    }
    ...
 
    Dictionary<string, string> data = new Dictionary<string, string>
    {
        {"ID_Id", "1"},
        {"ID_Name", "John"}
        ...
    };
    ...
    // Implement the `INotifyPropertyChanged` interface on this property
    public ObservableCollection<CustomObject> CustomObjects { get; set; }
    ...
