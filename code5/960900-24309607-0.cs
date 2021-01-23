	if (_leftClickCounter == 1 && _capturedLeft == false)
	{
		if (_dic.ContainsKey(Key.OnClick))
		{
			Action<object> action = _dic[Key.OnClick];
			// action.Invoke(null);			
			System.Windows.Application.Current.Dispatcher.BeginInvoke( call your action )
		}
	}
