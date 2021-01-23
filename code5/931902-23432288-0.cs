    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace App.ViewModel
    {
        public sealed class MyViewModel : INotifyPropertyChanged
        {
            #region BindableBase implementation
            /// <summary>
            /// Multicast event for property change notifications.
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;
    
            /// <summary>
            /// Checks if a property already matches a desired value.  Sets the property and
            /// notifies listeners only when necessary.
            /// </summary>
            /// <typeparam name="T">Type of the property.</typeparam>
            /// <param name="storage">Reference to a property with both getter and setter.</param>
            /// <param name="value">Desired value for the property.</param>
            /// <param name="propertyName">Name of the property used to notify listeners.  This
            /// value is optional and can be provided automatically when invoked from compilers that
            /// support CallerMemberName.</param>
            /// <returns>True if the value was changed, false if the existing value matched the
            /// desired value.</returns>
            protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
            {
                if (object.Equals(storage, value)) return false;
    
                storage = value;
                this.OnPropertyChanged(propertyName);
                return true;
            }
    
            /// <summary>
            /// Notifies listeners that a property value has changed.
            /// </summary>
            /// <param name="propertyName">Name of the property used to notify listeners.  This
            /// value is optional and can be provided automatically when invoked from compilers
            /// that support <see cref="CallerMemberNameAttribute"/>.</param>
            private void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var eventHandler = this.PropertyChanged;
                if (eventHandler != null)
                {
                    eventHandler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            #endregion
    
             #region MyImage
            /// <summary>
            /// Backing field for the MyImage property.
            /// </summary>
            private ImageSource myImage;
    
            /// <summary>
            /// Gets or sets a value indicating ....
            /// </summary>
            public string MyImage
            {
                get { return this.myImage; }
                set { this.SetProperty(ref this.myImage, value); }
            }
            #endregion
        }
    }
