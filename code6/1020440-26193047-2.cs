	public MyModel ViewModel
        {
	...
            set
            {
                DataContext = value;                
                Binding binding = new Binding();
                binding.Source = value.ErrorMessage;
                ErrorMessageProperty.SetBinding(binding);
            }
         ...
        }
