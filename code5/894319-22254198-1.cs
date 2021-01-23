    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Xml.Serialization;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                DataContext = new UserPreferences();
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                ((UserPreferences) DataContext).SelectedCollectionDevice.ComPort = 11;
            }
    
        }
    
        /// <summary>
        /// Provides a series of user preferences.
        /// </summary>
        [Serializable]
        public class UserPreferences : INotifyPropertyChanged
        {
            private CollectionDevice selectedCollectionDevice;
    
            public UserPreferences()
            {
                this.AvailableCollectionDevices = new List<CollectionDevice>();
    
                var yuma1 = new CollectionDevice
                {
                    BaudRate = 4800,
                    ComPort = 31,
                    DataPoints = 1,
                    Name = "Trimble Yuma 1",
                    WAAS = true
                };
    
                var yuma2 = new CollectionDevice
                {
                    BaudRate = 4800,
                    ComPort = 3,
                    DataPoints = 1,
                    Name = "Trimble Yuma 2",
                    WAAS = true
                };
    
                var toughbook = new CollectionDevice
                {
                    BaudRate = 4800,
                    ComPort = 3,
                    DataPoints = 1,
                    Name = "Panasonic Toughbook",
                    WAAS = true
                };
    
    
                var other = new CollectionDevice
                {
                    BaudRate = 0,
                    ComPort = 0,
                    DataPoints = 0,
                    Name = "Other",
                    WAAS = false
                };
    
                this.AvailableCollectionDevices.Add(yuma1);
                this.AvailableCollectionDevices.Add(yuma2);
                this.AvailableCollectionDevices.Add(toughbook);
                this.AvailableCollectionDevices.Add(other);
    
                this.SelectedCollectionDevice = this.AvailableCollectionDevices.First();
            }
    
            /// <summary>
            /// Gets or sets the GPS collection device.
            /// </summary>
            public CollectionDevice SelectedCollectionDevice
            {
                get
                {
                    return selectedCollectionDevice;
                }
                set
                {
                    selectedCollectionDevice = value;
                    this.OnPropertyChanged("SelectedCollectionDevice");
                }
            }
    
            /// <summary>
            /// Gets or sets a collection of devices that can be used for collecting GPS data.
            /// </summary>
            [XmlIgnore]
            public List<CollectionDevice> AvailableCollectionDevices { get; set; }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            /// <summary>
            /// Notifies objects registered to receive this event that a property value has changed.
            /// </summary>
            /// <param name="propertyName">The name of the property that was changed.</param>
            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
        /// <summary>
        /// CollectionDevice model
        /// </summary>
        [Serializable]
        public class CollectionDevice : INotifyPropertyChanged
        {
            /// <summary>
            /// Gets or sets the COM port.
            /// </summary>
            private int comPort;
    
            /// <summary>
            /// Gets or sets a value indicating whether [waas].
            /// </summary>
            private bool waas;
    
            /// <summary>
            /// Gets or sets the data points.
            /// </summary>
            private int dataPoints;
    
            /// <summary>
            /// Gets or sets the baud rate.
            /// </summary>
            private int baudRate;
    
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            public string Name { get; set; }
    
            /// <summary>
            /// Gets or sets the COM port.
            /// </summary>
            public int ComPort
            {
                get
                {
                    return this.comPort;
                }
    
                set
                {
                    this.comPort = value;
                    this.OnPropertyChanged("ComPort");
                }
            }
    
            /// <summary>
            /// Gets or sets the COM port.
            /// </summary>
            public bool WAAS
            {
                get
                {
                    return this.waas;
                }
    
                set
                {
                    this.waas = value;
                    this.OnPropertyChanged("WAAS");
                }
            }
    
            /// <summary>
            /// Gets or sets the COM port.
            /// </summary>
            public int DataPoints
            {
                get
                {
                    return this.dataPoints;
                }
    
                set
                {
                    this.dataPoints = value;
                    this.OnPropertyChanged("DataPoints");
                }
            }
    
            /// <summary>
            /// Gets or sets the COM port.
            /// </summary>
            public int BaudRate
            {
                get
                {
                    return this.baudRate;
                }
    
                set
                {
                    this.baudRate = value;
                    this.OnPropertyChanged("BaudRate");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            /// <summary>
            /// Notifies objects registered to receive this event that a property value has changed.
            /// </summary>
            /// <param name="propertyName">The name of the property that was changed.</param>
            protected virtual void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public override string ToString()
            {
                return this.Name;
            }
        }
    }
