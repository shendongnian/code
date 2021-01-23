    public static class Extensions
    {
        public static IObservable<T> OnPropertyChanges<T>(this T source, string propertyName)
            where T : INotifyPropertyChanged
        {
            return Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    handler => handler.Invoke,
                    h => source.PropertyChanged += h,
                    h => source.PropertyChanged -= h)
                    .Where(p => p.EventArgs.PropertyName == propertyName)
                    .Select(_ => source);
        }
    }
