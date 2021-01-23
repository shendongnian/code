    /// <summary>
    ///     The session manager
    /// </summary>
    
    public sealed class SessionManager 
    {
    	#region ISessionManager Members
    
    	/// <summary>
    	///     Clears the session.
    	/// </summary>
    	public void ClearSession()
    	{
    		HttpContext.Current.Session.Clear();
    		HttpContext.Current.Session.Abandon(); //Abandon ends the entire session (the user gets a new SessionId)
    	}
    
    	/// <summary>
    	///     Gets or sets the current employe.
    	/// </summary>
    	/// <value>The current employe.</value>
    	public EmployeDto CurrentEmploye
    	{
    		get { return Get<EmployeDto>(); }
    		set { Add(value); }
    	}
    
    	/// <summary>
    	///     Gets or sets the parameters.
    	/// </summary>
    	/// <value>The parameters.</value>
    	public IList<ParameterDto> Parameters
    	{
    		get { return Get<List<ParameterDto>>() ?? new List<ParameterDto>(); }
    		set { Add(value); }
    	}
    
    	#endregion
    
    	#region Methods
    
    	/// <summary>
    	///     Adds the specified key.
    	/// </summary>
    	/// <typeparam name="T"></typeparam>
    	/// <param name="value">The value.</param>
    	/// <param name="key">The key.</param>
    	/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    	/// <exception cref="System.ArgumentNullException">key</exception>
    	/// <exception cref="System.Exception">Session elements cannot be added when session is disabled.</exception>
    	public static bool Add<T>(T value, [CallerMemberName] string key = null)
    	{
    		if (key == null) throw new ArgumentNullException("key");
    		HttpContext current = HttpContext.Current;
    
    		if (current == null)
    		{
    			return false;
    		}
    
    		if (current.Session.Mode == SessionStateMode.Off)
    		{
    			throw new Exception("Session elements cannot be added when session is disabled.");
    		}
    
    		current.Session.Add(key, value);
    
    		return true;
    	}
    
    	/// <summary>
    	///     Gets the specified key.
    	/// </summary>
    	/// <typeparam name="T"></typeparam>
    	/// <param name="key">The key.</param>
    	/// <returns>``0.</returns>
    	/// <exception cref="System.ArgumentNullException">key</exception>
    	/// <exception cref="System.Exception">Session elements cannot be added when session is disabled.</exception>
    	public static T Get<T>([CallerMemberName] string key = null) where T : class
    	{
    		if (key == null) throw new ArgumentNullException("key");
    		HttpContext current = HttpContext.Current;
    
    		if (current.Session.Mode == SessionStateMode.Off)
    		{
    			throw new Exception("Session elements cannot be added when session is disabled.");
    		}
    
    		return current.Session[key] as T;
    	}
    
    	/// <summary>
    	///     Gets the specified key.
    	/// </summary>
    	/// <param name="key">The key.</param>
    	/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    	/// <exception cref="System.ArgumentNullException">key</exception>
    	/// <exception cref="System.Exception">Session elements cannot be added when session is disabled.</exception>
    	public static bool Get([CallerMemberName] string key = null)
    	{
    		if (key == null) throw new ArgumentNullException("key");
    		HttpContext current = HttpContext.Current;
    
    		if (current.Session.Mode == SessionStateMode.Off)
    		{
    			throw new Exception("Session elements cannot be added when session is disabled.");
    		}
    		bool result = false;
    		bool.TryParse(current.Session[key].ToString(), out result);
    		return result;
    	}
    
    	/// <summary>
    	///     Removes the specified key.
    	/// </summary>
    	/// <param name="key">The key.</param>
    	/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    	/// <exception cref="System.ArgumentNullException">key</exception>
    	/// <exception cref="System.Exception">Session elements cannot be added when session is disabled.</exception>
    	public static bool Remove(string key)
    	{
    		if (key == null) throw new ArgumentNullException("key");
    		HttpContext current = HttpContext.Current;
    
    		if (current == null)
    		{
    			return false;
    		}
    
    		if (current.Session.Mode == SessionStateMode.Off)
    		{
    			throw new Exception("Session elements cannot be added when session is disabled.");
    		}
    
    		current.Session.Remove(key);
    
    		return true;
    	}
    
    	#endregion
    }
