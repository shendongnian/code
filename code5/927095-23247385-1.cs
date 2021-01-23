    /// <summary>EventArgs for notifying about changed values.</summary>
    /// <typeparam name="T">The type of the contained value.</typeparam>
    public class ValueChangedEventArgs<T> : EventArgs
    {
    	/// <summary>Initializes a new instance of the <see cref="ValueChangedEventArgs{T}" /> class.</summary>
    	/// <param name="newValue">The new value.</param>
    	/// <param name="oldValue">The old value.</param>
    	public ValueChangedEventArgs(T newValue, T oldValue)
    	{
    		NewValue = newValue;
    		OldValue = oldValue;
    	}
    
    	/// <summary>Gets the new value.</summary>
    	/// <value>The new value.</value>
    	public T NewValue { get; private set; }
    	/// <summary>Gets the old value.</summary>
    	/// <value>The old value.</value>
    	public T OldValue { get; private set; }
    }
