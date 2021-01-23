    using System.ComponentModel;
    using System.Windows;
    namespace BusyIndicatorExample
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private AbortableBackgroundWorker _worker;
