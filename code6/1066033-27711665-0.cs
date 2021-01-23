        /// <summary>
        /// The current visiblity of this user control.
        /// </summary>
        private Visibility _visibility;
        /// <summary>
        /// Gets or sets the visibility of a UIElement.
        /// A UIElement that is not visible is not rendered and does not communicate its desired size to layout.
        /// </summary>
        /// <returns>A value of the enumeration. The default value is Visible.</returns>
        public new Visibility Visibility
        {
            get { return _visibility; }
            set
            {
                bool differ = false;
                if (value != _visibility)
                {
                    _visibility = value;
                    differ = true;
                }
                base.Visibility = value;
                if (differ)
                {
                    RaiseVisibilityChanged(value);
                }
            }
        }
        /// <summary>
        /// Raised when the <see cref="Visibility"/> property changes.
        /// </summary>
        public event EventHandler<VisibilityChangedEventArgs> VisibilityChanged;
        /// <summary>
        /// Raises the <see cref="VisibilityChanged"/> event of this command bar.
        /// </summary>
        /// <param name="visibility">The new visibility value.</param>
        private void RaiseVisibilityChanged(Visibility visibility)
        {
            if (VisibilityChanged != null)
            {
                VisibilityChanged(this, new VisibilityChangedEventArgs(visibility));
            }
        }
        /// <summary>
        /// Contains the arguments for the <see cref="SampleViewModel.VisibilityChanged"/> event.
        /// </summary>
        public sealed class VisibilityChangedEventArgs : EventArgs
        {
            /// <summary>
            /// The new visibility.
            /// </summary>
            public Visibility NewVisibility { get; private set; }
            /// <summary>
            /// Initializes a new instance of the <see cref="VisibilityChangedEventArgs"/> class.
            /// <param name="newVisibility">The new visibility.</param>
            /// </summary>
            public VisibilityChangedEventArgs(Visibility newVisibility)
            {
                this.NewVisibility = newVisibility;
            }
        }
