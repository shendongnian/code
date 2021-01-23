    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using Microsoft.Phone.Controls;
    
    namespace WP8MultiBinding
    {
        public partial class MainPage : PhoneApplicationPage
        {
            public MainPage()
            {
                InitializeComponent();
                WorkUnit = new WorkUnit()
                    {
                        To = DateTime.Now.AddHours(5),
                        From = DateTime.Now,
                        Type = WorkUnitType.StartEnd
                    };
            }
    
            public WorkUnit WorkUnit { get; set; }
    
            // Ensure bindings do update
            private void UpdateButtonClick(object sender, RoutedEventArgs e)
            {
                WorkUnit.Type = WorkUnit.Type == WorkUnitType.StartEnd ? 
                                WorkUnit.Type = WorkUnitType.Other : 
                                WorkUnit.Type = WorkUnitType.StartEnd;
    
                WorkUnit.From = WorkUnit.From.AddHours(60);
                if (WorkUnit.To.HasValue)
                    WorkUnit.To = WorkUnit.To.Value.AddMinutes(30);
            }
        }
    
        public enum WorkUnitType
        {
            StartEnd,
            Other
        }
    
        public class WorkUnit : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private WorkUnitType _type;
            private DateTime _from;
            private DateTime? _to;
    
            public WorkUnitType Type
            {
                get { return _type; }
                set { _type = value; OnPropertyChanged(); }
            }
    
            public DateTime From
            {
                get { return _from; }
                set { _from = value; OnPropertyChanged(); }
            }
    
            public DateTime? To
            {
                get { return _to; }
                set { _to = value; OnPropertyChanged(); }
            }
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null) 
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        // Multivalue Converter
        public class WorkUnitToEndTimeStringConverter : Krempel.WP7.Core.Controls.IMultiValueConverter
        {
            private const string DateFormat = "M/d/yyyy h:mm:ss tt";
    
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                // Index: 0 = Type, 1 = From, 2 = To
                if (values[2] != null)
                {
                    var type = (WorkUnitType) Enum.Parse(typeof (WorkUnitType), values[0].ToString());
                    var from = DateTime.ParseExact(values[1].ToString(), DateFormat, CultureInfo.InvariantCulture);
                    var to = DateTime.ParseExact(values[2].ToString(), DateFormat, CultureInfo.InvariantCulture);
    
                    if (type == WorkUnitType.StartEnd)
                        return to.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern);
    
                    var duration = to - from;
                    return duration; // DateHelper.FormatTime(duration, false);
                }
    
                return null;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
    }
