    /// <summary>
    /// An observable collection that supports batch changes without sending CollectionChanged
    /// notifications for each individual modification
    /// </summary>
    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {
    	/// <summary>
    	/// While true, CollectionChanged notifications will not be sent.
    	/// When set to false, a NotifyCollectionChangedAction.Reset will be sent.
    	/// </summary>
    	public bool IsBatchModeActive
    	{
    		get { return _isBatchModeActive; }
    		set
    		{
    			_isBatchModeActive = value;
    
    			if (_isBatchModeActive == false)
    			{
    				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    			}
    		}
    	}
    	private bool _isBatchModeActive;
    
    	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    	{
    		if (!IsBatchModeActive)
    		{
    			base.OnCollectionChanged(e);
    		}
    	}
    }
