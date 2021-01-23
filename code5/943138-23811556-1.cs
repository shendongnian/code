    using System;
    using System.Reactive.Linq;
    using System.Windows;
    using System.Windows.Controls;
    namespace StackoverFlow_23764884
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            
                var source = meh.ObserveTextChanged();
                var disableSpellcheck = source.Select(_ => false);
                var enableSpellcheck = source.Select(_ => Observable.Timer(TimeSpan.FromSeconds(1)))
                                             .Switch()
                                             .Select(_ => true);
                disableSpellcheck.Merge(enableSpellcheck)
                                 .DistinctUntilChanged()
                                 .ObserveOnDispatcher()
                                 .Subscribe(isEnabled => spellChecking.IsChecked=isEnabled);
            }
        }
        public static class ObEx
        {
            public static IObservable<EventArgs> ObserveTextChanged(this RichTextBox rtb)
            {
                return Observable.FromEventPattern<TextChangedEventHandler, EventArgs>(
                    h => rtb.TextChanged += h,
                    h => rtb.TextChanged -= h)
                    .Select(ep => ep.EventArgs);
            }
        }
    }
