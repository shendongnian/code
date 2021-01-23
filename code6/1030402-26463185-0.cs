    public interface ISelectableItem<T, T2>
    {
        T Value { get; set; }
        ObservableCollection<ISelectableItem<T2>> SubItems { get; }
    }
