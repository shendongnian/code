	public class VmSomeEntity : ViewModelBase, INotifyDataErrorInfo
	{
		//This one is part of INotifyDataErrorInfo interface which I will not use,
		//perhaps in more complicated scenarios it could be used to let some other VM know validation changed.
		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged; 
		//will hold the errors found in validation.
		public Dictionary<string, string> ValidationErrors = new Dictionary<string, string>();
		//the actual value - notice it is 'int' and not 'string'..
		private int storageCapacityInBytes;
		//this is just to keep things sane - otherwise the view will not be able to send whatever the user throw at it.
		//we want to consume what the user throw at us and validate it - right? :)
		private string storageCapacityInBytesWrapper;
		//This is a property to be served by the View.. important to understand the tactic used inside!
		public string StorageCapacityInBytes
		{
		   get { return storageCapacityInBytesWrapper ?? storageCapacityInBytes.ToString(); }
		   set
		   {
			  int result;
			  var isValid = int.TryParse(value, out result);
			  if (isValid)
			  {
				 storageCapacityInBytes = result;
				 storageCapacityInBytesWrapper = null;
				 RaisePropertyChanged();
			  }
			  else
				 storageCapacityInBytesWrapper = value;         
			  HandleValidationError(isValid, "StorageCapacityInBytes", "Not a number.");
		   }
		}
		//Manager for the dictionary
		private void HandleValidationError(bool isValid, string propertyName, string validationErrorDescription)
		{
			if (!string.IsNullOrEmpty(propertyName))
			{
				if (isValid)
				{
					if (ValidationErrors.ContainsKey(propertyName))
						ValidationErrors.Remove(propertyName);
				}
				else
				{
					if (!ValidationErrors.ContainsKey(propertyName))
						ValidationErrors.Add(propertyName, validationErrorDescription);
					else
						ValidationErrors[propertyName] = validationErrorDescription;
				}
			}
		}
        
		// this is another part of the interface - will be called automatically
		public IEnumerable GetErrors(string propertyName)
		{
			return ValidationErrors.ContainsKey(propertyName)
				? ValidationErrors[propertyName]
				: null;
		}
		// same here, another part of the interface - will be called automatically
		public bool HasErrors
		{
			get
			{
				return ValidationErrors.Count > 0;
			}
		}
	}
