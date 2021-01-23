    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using StackOverflow.Rx.Annotations;
    using StackOverflow.Rx.Model;
    namespace StackOverflow.Rx.ProductSearch
    {
        public class ClassicProductSearchViewModel : INotifyPropertyChanged
        {
            private string _query;
            private IProductRepository _productRepository;
            private IList<Product> _productSearchResults;
            public ClassicProductSearchViewModel(IProductRepository productRepository)
            {
                _productRepository = productRepository;
                // Wire up a Button from the view to this command with a binding like
                // <Button Content="Search" Command="{Binding ImmediateSearch}"/>
                ImmediateSearch = new ReactiveCommand();
                // Wire up the Query text from the view with
                // a binding like <TextBox MinWidth="100" Text="{Binding Query, UpdateSourceTrigger=PropertyChanged}"/>
                var newQueryText = Observable.FromEventPattern<PropertyChangedEventHandler, PropertyChangedEventArgs>(
                    h => PropertyChanged += h,
                    h => PropertyChanged -= h)
                    .Where(@event => @event.EventArgs.PropertyName == "Query")
                    .Select(_ => Query);
                // This duration selector will emit EITHER after the delay OR when the command executes
                var throttleDurationSelector = Observable.Return(Unit.Default)
                                                         .Delay(TimeSpan.FromSeconds(2))
                                                         .Merge(ImmediateSearch.Select(x => Unit.Default));
                newQueryText
                    .Throttle(x => throttleDurationSelector)
                    .DistinctUntilChanged()
                    /* Your search query here */
                    .Select(
                        text =>
                            Observable.StartAsync(
                                () => _productRepository.FindProducts(new ProductNameStartsWithSpecification(text))))
                    .Switch()
                    .ObserveOnDispatcher()
                    .Subscribe(products => ProductSearchResults = new List<Product>(products));
            }
            public IList<Product> ProductSearchResults
            {
                get { return _productSearchResults; }
                set
                {
                    if (Equals(value, _productSearchResults)) return;
                    _productSearchResults = value;
                    OnPropertyChanged();
                }
            }
            public ReactiveCommand ImmediateSearch { get; set; }
            public string Query
            {
                get { return _query; }
                set
                {
                    if (value == _query) return;
                    _query = value;
                    OnPropertyChanged();
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        // A command that is also an IObservable!
        public class ReactiveCommand : ICommand, IObservable<object>
        {
            private bool _canExecute = true;
            private readonly Subject<object> _execute = new Subject<object>();
            public ReactiveCommand(IObservable<bool> canExecute = null)
            {
                if (canExecute != null)
                {
                    canExecute.Subscribe(x => _canExecute = x);
                }
            }
            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }
            public void Execute(object parameter)
            {
                _execute.OnNext(parameter);
            }
            public event EventHandler CanExecuteChanged;
            public IDisposable Subscribe(IObserver<object> observer)
            {
                return _execute.Subscribe(observer);
            }
        }
    }
