using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace MyNamespace
{
    // This base view model takes care of implementing INotifyPropertyChanged
    // In your extended View Model classes, use SetValue in your setters.
    // This will take care of notifying your ObservableCollection and hence
    // updating your UI bound to that collection when your view models change.
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value)) return;
            backingField = value;
            OnPropertyChanged(propertyName);
        }
            
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    // Using MvvM, this would likely be a View Model class.
    // However, it could also be a simple POCO model class
    public class MyListItem : BaseViewModel
    {
        private string _itemLabel = "List Item Label";
        public string Label
        {
            get => _itemLabel;
            set => SetValue(ref _itemLabel, value);
        }
    }
    // This is your MvvM View Model
    // This would typically be your BindingContext on your Page that includes your List View
    public class MyViewModel : BaseViewModel
    {
        private ObservableCollection<MyListItem> _myListItemCollection
            = new ObservableCollection<MyListItem>();
        
        public ObservableCollection<MyListItem> MyListItemCollection
        {
            get { return _myListItemCollection; }
            set => SetValue(ref _myListItemCollection, value);
        }
    }
    
}
