    var binding = new Binding
                    {
                        Source = myModelBase,
                        Path = new PropertyPath("Model."+nameOfProperty),
                        Mode = BindingMode.Default,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    };
