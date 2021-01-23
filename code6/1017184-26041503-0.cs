        /// <summary>
        /// Gets or sets...
        /// </summary>
        public IObservableList<Port> Ports
        {
            get { return (IObservableList<Port>)GetValue(PortsProperty); }
            set { SetValue(PortsProperty, value); }
        }
        public static readonly DependencyProperty PortsProperty = DependencyProperty.Register("Ports", typeof(IObservableList<Port>), typeof(MyViewModelClass), new PropertyMetadata(new ObservableList<Port>));
