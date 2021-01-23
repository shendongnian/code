    public interface ISelectableItem<T, T2> : ISelectableItem<T>
    {
        ObservableCollection<ISelectableItem<T2>> SubItems { get; }
    }
    public interface ISelectableItem<T>
    {
        bool IsSelected { get; set; }
        bool IsVisible { get; set; }
        string DisplayName { get; set; }
        T Value { get; set; }
    }
