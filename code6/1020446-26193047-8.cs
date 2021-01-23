	public MyModel ViewModel
        {
	...
            set
            {
                DataContext = value;                
                Binding binding = new Binding();
                binding.Source = value;
                binding.Path = new PropertyPath("ErrorMessage");
                SetBinding(ErrorMessageProperty, binding);
            }
         ...
        }
