    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Runtime.CompilerServices;
    using System.ComponentModel;
    
    namespace WpfApplication1 {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window {
            public MainWindow () {
                InitializeComponent();
    
                Parameter testParameter = new Parameter(0, 10);
                testGrid.DataContext = testParameter;
            }
        }
    
        public class Parameter: INotifyPropertyChanged, IDataErrorInfo {
            private decimal _start, _end, _min, _max;
            public event PropertyChangedEventHandler PropertyChanged;
    
            public Parameter () { }
    
            public Parameter (decimal min, decimal max) {
                this.Min = min;
                this.Max = max;
            }
    
            public decimal Start {
                get { return _start; }
                set {
                    _start = value;
                    //RaisePropertyChanged for both Start and End, because one may need to be marked as invalid because of the other's current setting.
                    //e.g. Start > End, in which case both properties are now invalid according to the established conditions, but only the most recently changed property will be validated
                    RaisePropertyChanged();
                    RaisePropertyChanged("End");
                }
            }
    
            public decimal End {
                get { return _end; }
                set {
                    _end = value;
                    //RaisePropertyChanged for both Start and End, because one may need to be marked as invalid because of the other's current setting.
                    //e.g. Start > End, in which case both properties are now invalid according to the established conditions, but only the most recently changed property will be validated
                    RaisePropertyChanged();
                    RaisePropertyChanged("Start");
                }
            }
    
            public decimal Min {
                get { return _min; }
                set { _min = value; }
            }
    
            public decimal Max {
                get { return _max; }
                set { _max = value; }
            }
    
            private void RaisePropertyChanged ([CallerMemberName] string propertyName = "") {
                if (PropertyChanged != null) {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    
            public string Error {
                get { return string.Empty; }
            }
    
            public string this[string columnName] {
                get {
                    string result = string.Empty;
    
                    switch (columnName) {
                        case "Start":
                            if (Start < Min || Start > Max || Start > End) {
                                result = "Out of range. Enter a value in the range: " + Min + " - " + End + ".";
                            }
                            break;
                        case "End":
                            if (End < Min || End > Max || End < Start) {
                                result = "Out of range. Enter a value in the range: " + Start + " - " + Max + ".";
                            }
                            break;
                    };
    
                    return result;
                }
            }
        }
    }
