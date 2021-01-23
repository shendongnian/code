    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace SearchAgent
    {
        class CancellableSearchAgent
        {
            // Note: using 'object' is a bit icky - it would be better to define an interface or base class,
            // or at least restrict the type of object in some way, such as by making CancellableSearchAgent
            // a template CancellableSearchAgent<T> and replacing every copy of the text 'object' in this
            // answer with the character 'T', then make sure that the RealSearch() method return a collection
            // of objects of type T.
            private Task<IEnumerable<object>> _searchTask;
            private CancellationTokenSource _tokenSource;
    
            // You can use this property to check how the search is going.
            public TaskStatus SearchState
            {
                get { return _searchTask.Status; }
            }
    
            // When the search has run to completion, this will contain the result,
            // otherwise it will be null.
            public IEnumerable<object> SearchResult { get; private set; }
    
            // Create a new CancellableSearchAgent for each search.  The class encapsulates the 'workflow'
            // preventing issues with null members, re-using completed tasks, etc, etc.
            // You can add parameters, such as SQL statements as necessary.
            public CancellableSearchAgent()
            {
                _tokenSource = new CancellationTokenSource();
                _searchTask = Task<IEnumerable<object>>.Factory.StartNew(() => RealSearch(), TaskScheduler.Default);
            }
    
            // This method can be called from the UI without blocking.
            // Use this if the CancellableSearchAgent is part of your ViewModel (Presenter/Controller).
            public async void AwaitResultAsync()
            {
                SearchResult = await _searchTask;
            }
    
            // This method can be called from the ViewModel (Presenter/Controller), but will block the UI thread
            // if called directly from the View, making the UI unresponsive and unavailable for the user to
            // cancel the search.
            // Use this if CancellableSearchAgent is part of your Model.
            public IEnumerable<object> AwaitResult()
            {
                if (null == SearchResult)
                {
                    try
                    {
                        _searchTask.Wait(_tokenSource.Token);
                        SearchResult = _searchTask.Result;
                    }
                    catch (OperationCanceledException) { }
                    catch (AggregateException)
                    {
                        // You may want to handle other exceptions, thrown by the RealSearch() method here.
                        // You'll find them in the InnerException property.
                        throw;
                    }
                }
                return SearchResult;
            }
    
            // This method can be called to cancel an ongoing search.
            public void CancelSearch()
            {
                _tokenSource.Cancel();
            }
        }
    }
