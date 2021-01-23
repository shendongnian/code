    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Windows.Input;
    namespace WpfApplication1
    {
    public class ViewModel
    {
        private readonly ObservableCollection<Item> _clone;
        private readonly ObservableCollection<Item> _source;
        private readonly Collection<Item> _changes = new Collection<Item>();
        public ViewModel(ObservableCollection<Item> items)
        {
            _source = items;            
            _clone = new ObservableCollection<Item>(items);
            _clone.CollectionChanged += clone_CollectionChanged;
        }
        void clone_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var newItem in e.NewItems.Cast<Item>())
                    {
                        _changes.Add(newItem);
                    }
                    break;
            }
        }
        public ObservableCollection<Item> Clone
        {
            get { return _clone; }
        }
        private DelegateCommand _commitChangesCommand;
        public ICommand CommitChangesCommand
        {
            get { return _commitChangesCommand ?? (_commitChangesCommand = new DelegateCommand(CommitChanges, CanCommitChanges)); }
        }
        private void CommitChanges(object sender)
        {
            foreach (var change in _changes)
            {
                _source.Add(change);
            }
            _changes.Clear();
        }
        private bool CanCommitChanges(object sender)
        {
            return _changes.Any();
        }
    }
    public class Item
    {
    }
    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        public event EventHandler CanExecuteChanged;
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public DelegateCommand(Action<object> execute,
            Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
    }
