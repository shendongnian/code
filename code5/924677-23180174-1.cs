    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Reactive.Linq;
    using System.Windows.Input;
    
    using ReactiveUI;
    
    namespace ReactiveExtensionsSearch
    {
        public class MainWindowViewModel : ReactiveObject
        {
            private string[] _repository = new string[]
                { "Mario", "Maria", "Gigi", "Jack", "James", "Jeremy" };
            private ObservableAsPropertyHelper<ObservableCollection<string>> _searchResults;
            private string _searchText;
            private ICommand _executeSearchCommand;
    
            public string SearchText
            {
                get
                {
                    return _searchText;
                }
                set
                {
                    this.RaiseAndSetIfChanged(ref _searchText, value);
                }
            }
    
            public ObservableCollection<string> SearchResults
            {
                get
                {
                    return _searchResults.Value;
                }
            }
    
            public MainWindowViewModel()
            {
                var executeSearchCommand = new ReactiveCommand();
                var results = executeSearchCommand.RegisterAsyncFunction(s => { return ExecuteSearch(s as string); });
                _executeSearchCommand = executeSearchCommand;
    
                this.ObservableForProperty<MainWindowViewModel, string>("SearchText")
                    .Throttle(TimeSpan.FromMilliseconds(800))
                    .Select(x => x.Value)
                    .DistinctUntilChanged()
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Subscribe(_executeSearchCommand.Execute);
    
               _searchResults = new ObservableAsPropertyHelper<ObservableCollection<string>>(results, _ => raisePropertyChanged("SearchResults"));
            }
    
            private ObservableCollection<string> ExecuteSearch(string searchText)
            {
                var q = from s in _repository where s.ToLower().StartsWith(searchText.ToLower()) select s;
                var results = new ObservableCollection<string>(q);
                return results;
            }
        }
    }
