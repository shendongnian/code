    private Subject<string> typingSubject = new Subject<string> ();
    private IDisposable typingEventSequence;
    
    private void Init () {
                var searchText = layoutView.FindViewById<EditText> (Resource.Id.search_text);
    			searchText.TextChanged += SearchTextChanged;
    			typingEventSequence = typingSubject.Throttle (TimeSpan.FromSeconds (1))
    				.Subscribe (query => suggestionsAdapter.Get (query));
    }
    
    private void SearchTextChanged (object sender, TextChangedEventArgs e) {
    			var searchText = layoutView.FindViewById<EditText> (Resource.Id.search_text);
    			typingSubject.OnNext (searchText.Text.Trim ());
    		}
    
    public override void OnDestroy () {
    			if (typingEventSequence != null)
    				typingEventSequence.Dispose ();
    			base.OnDestroy ();
    		}
