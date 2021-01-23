    public class VIewModelBase : IDataErrorInfo
	{
		
		private Dictionary<string, string> errors = new Dictionary<string, string>();
		// required for IDataErrorInfo
		public virtual string Error
		{
			get { return String.Join(Environment.NewLine, errors); }
		}
		
		// required for IDataErrorInfo
		public string this[string propertyName]
		{
			get
			{
				string result;
				errors.TryGetValue(propertyName, out result);
				return result;
			}
		}
		
		// Useful property to check if you have errors
		public bool HasErrors
		{
			get
			{
				return errors.Count > 0;
			}
		}
		
		protected void SetError<T>(string propertyName, String error)
		{
			if (error == null)
				errors.Remove(propertyName);
			else
				errors[propertyName] = error;
		
			OnHasErrorsChanged();
		}
		protected string GetError<T>(string propertyName, String error)
		{
			String s;
			errors.TryGetValue(propertyName, out s);
			return s;
		}
		
		protected virtual void OnHasErrorsChanged()
		{
		
		}
	}
