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
    
    namespace Stv.AutoCatch.Desktop.Client.Infrastructure.Controls
    {
        /// <summary>
        /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
        ///
        /// Step 1a) Using this custom control in a XAML file that exists in the current project.
        /// Add this XmlNamespace attribute to the root element of the markup file where it is 
        /// to be used:
        ///
        ///     xmlns:MyNamespace="clr-namespace:Stv.AutoCatch.Desktop.Client.Infrastructure.Controls"
        ///
        ///
        /// Step 1b) Using this custom control in a XAML file that exists in a different project.
        /// Add this XmlNamespace attribute to the root element of the markup file where it is 
        /// to be used:
        ///
        ///     xmlns:MyNamespace="clr-namespace:Stv.AutoCatch.Desktop.Client.Infrastructure.Controls;assembly=Stv.AutoCatch.Desktop.Client.Infrastructure.Controls"
        ///
        /// You will also need to add a project reference from the project where the XAML file lives
        /// to this project and Rebuild to avoid compilation errors:
        ///
        ///     Right click on the target project in the Solution Explorer and
        ///     "Add Reference"->"Projects"->[Browse to and select this project]
        ///
        ///
        /// Step 2)
        /// Go ahead and use your control in the XAML file.
        ///
        ///     <MyNamespace:TimeCodeUpDown/>
        ///
        /// </summary>
        public class TimeCodeUpDown : Control
        {
            TextBox _lastFocusedTextBox;
    
            internal TimeSpan InternalTime
            {
                get { return _internalTime; }
            }
            TimeSpan _internalTime = TimeSpan.Zero;
    
            static TimeCodeUpDown()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeCodeUpDown), new FrameworkPropertyMetadata(typeof(TimeCodeUpDown)));
            }
    
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                Button upButton = (Button)base.GetTemplateChild("UpButton");
                Button downButton = (Button)base.GetTemplateChild("DownButton");
    
                upButton.Click += upButton_Click;
                downButton.Click += downButton_Click;
    
                TextBox hoursText = (TextBox)base.GetTemplateChild("HoursText");
                hoursText.GotFocus += _hoursText_GotFocus;
    
                TextBox minutesText = (TextBox)base.GetTemplateChild("MinutesText");
                minutesText.GotFocus += _minutesText_GotFocus;
    
                TextBox secondsText = (TextBox)base.GetTemplateChild("SecondsText");
                secondsText.GotFocus += _secondsText_GotFocus;
    
                TextBox framesText = (TextBox)base.GetTemplateChild("FramesText");
                framesText.GotFocus += _framesText_GotFocus;
            }
    
            void _framesText_GotFocus(object sender, RoutedEventArgs e)
            {
                _lastFocusedTextBox = (TextBox)sender;
            }
    
            void _secondsText_GotFocus(object sender, RoutedEventArgs e)
            {
                _lastFocusedTextBox = (TextBox)sender;
            }
    
            void _minutesText_GotFocus(object sender, RoutedEventArgs e)
            {
                _lastFocusedTextBox = (TextBox)sender;
            }
    
            void _hoursText_GotFocus(object sender, RoutedEventArgs e)
            {
                _lastFocusedTextBox = (TextBox)sender;
            }
    
            void downButton_Click(object sender, RoutedEventArgs e)
            {
                if (_lastFocusedTextBox != null)
                {
                    if (_lastFocusedTextBox.Name.Equals("HoursText"))
                    {
                        if (this.Hours > 0)
                            this.Hours--;
                        else if (this.Hours == 0)
                            this.Hours = 23;
    
                    }
                    if (_lastFocusedTextBox.Name.Equals("MinutesText"))
                    {
                        if (this.Minutes > 0)
                            this.Minutes--;
                        else if (this.Minutes == 0)
                            this.Minutes = 59;
                    }
                    if (_lastFocusedTextBox.Name.Equals("SecondsText"))
                    {
                        if (this.Seconds > 0)
                            this.Seconds--;
                        else if (this.Seconds == 0)
                            this.Seconds = 59;
                    }
                    if (_lastFocusedTextBox.Name.Equals("FramesText"))
                    {
                        if (this.Frames > 0)
                            this.Frames--;
                        else if (this.Frames == 0)
                            this.Frames = 24;
                    }
                }
            }
    
            void upButton_Click(object sender, RoutedEventArgs e)
            {
                if (_lastFocusedTextBox != null)
                {
    
                    if (_lastFocusedTextBox.Name.Equals("HoursText"))
                    {
                        if (this.Hours < 23)
                            this.Hours++;
                        else if (this.Hours == 23)
                            this.Hours = 0;
    
                    }
                    if (_lastFocusedTextBox.Name.Equals("MinutesText"))
                    {
                        if (this.Minutes < 59)
                            this.Minutes++;
                        else if (this.Minutes == 59)
                            this.Minutes = 0;
                    }
                    if (_lastFocusedTextBox.Name.Equals("SecondsText"))
                    {
                        if (this.Seconds < 59)
                            this.Seconds++;
                        else if (this.Seconds == 59)
                            this.Seconds = 0;
                    }
                    if (_lastFocusedTextBox.Name.Equals("FramesText"))
                    {
                        if (this.Frames < 24)
                            this.Frames++;
                        else if (this.Frames == 24)
                            this.Frames = 0;
                    }
                }
            }
    
            public TimeSpan TimeValue
            {
                get { return (TimeSpan)GetValue(TimeValueProperty); }
                set { SetValue(TimeValueProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for TimeValue.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty TimeValueProperty =
                DependencyProperty.Register("TimeValue", typeof(TimeSpan), typeof(TimeCodeUpDown), new PropertyMetadata(TimeSpan.Zero, new PropertyChangedCallback(OnTimeValueChanged)));
    
            private static void OnTimeValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var instance = (TimeCodeUpDown)d;
    
                TimeSpan newValue = (TimeSpan)e.NewValue;
                if (newValue < TimeSpan.Zero || newValue >= TimeSpan.FromDays(1))  // ensure TimeSpan is less than 1 day and not negative.
                    newValue = new TimeSpan(0, newValue.Hours, newValue.Minutes, newValue.Seconds, newValue.Milliseconds);
    
                if(!instance._internalTime.Equals(newValue))
                {
                    // we are being changed from outside the control.
                    var absoluteTime = Convert.ToInt64(25 * newValue.TotalSeconds);
    
    
                    instance.Hours = Convert.ToInt32((absoluteTime / 90000) % 24);
                    instance.Minutes = Convert.ToInt32((absoluteTime - (90000 * instance.Hours)) / 1500);
                    instance.Seconds = Convert.ToInt32(((absoluteTime - (1500 * instance.Minutes) - (90000 * instance.Hours)) / 25));
                    instance.Frames = Convert.ToInt32(absoluteTime - (25 * instance.Seconds) - (1500 * instance.Minutes) - (90000 * instance.Hours));
                }
            }
    
    
            //internal ICommand
    
    
    
            public int Hours
            {
                get { return (int)GetValue(HoursProperty); }
                set { SetValue(HoursProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Hours.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty HoursProperty =
                DependencyProperty.Register("Hours", typeof(int), typeof(TimeCodeUpDown), new PropertyMetadata(0, new PropertyChangedCallback(OnHoursChanged)));
    
            private static void OnHoursChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var instance = (TimeCodeUpDown)d;
                TimeSpan newTime =
                    new TimeSpan(0, (int)e.NewValue, instance.TimeValue.Minutes, instance.TimeValue.Seconds, instance.TimeValue.Milliseconds);
                instance._internalTime = newTime;
                instance.TimeValue = newTime;
            }
    
    
    
            public int Minutes
            {
                get { return (int)GetValue(MinutesProperty); }
                set { SetValue(MinutesProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Minutes.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty MinutesProperty =
                DependencyProperty.Register("Minutes", typeof(int), typeof(TimeCodeUpDown), new PropertyMetadata(0, new PropertyChangedCallback(OnMinutesChanged)));
    
            private static void OnMinutesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var instance = (TimeCodeUpDown)d;
                TimeSpan newTime =
                    new TimeSpan(0, instance.TimeValue.Hours, (int)e.NewValue, instance.TimeValue.Seconds, instance.TimeValue.Milliseconds);
                instance._internalTime = newTime;
                instance.TimeValue = newTime;
            }
    
    
    
    
            public int Seconds
            {
                get { return (int)GetValue(SecondsProperty); }
                set { SetValue(SecondsProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Seconds.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SecondsProperty =
                DependencyProperty.Register("Seconds", typeof(int), typeof(TimeCodeUpDown), new PropertyMetadata(0, new PropertyChangedCallback(OnSecondsChanged)));
    
            private static void OnSecondsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var instance = (TimeCodeUpDown)d;
                TimeSpan newTime =
                    new TimeSpan(0, instance.TimeValue.Hours, instance.TimeValue.Minutes, (int)e.NewValue, instance.TimeValue.Milliseconds);
                instance._internalTime = newTime;
                instance.TimeValue = newTime;
            }
    
            public int Frames
            {
                get { return (int)GetValue(FramesProperty); }
                set { SetValue(FramesProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Frames.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty FramesProperty =
                DependencyProperty.Register("Frames", typeof(int), typeof(TimeCodeUpDown), new PropertyMetadata(0, new PropertyChangedCallback(OnFramesChanged)));
    
            private static void OnFramesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var instance = (TimeCodeUpDown)d;
                TimeSpan newTime =
                    new TimeSpan(0, instance.TimeValue.Hours, instance.TimeValue.Minutes, instance.TimeValue.Seconds, (int)e.NewValue * 40);
                instance._internalTime = newTime;
                instance.TimeValue = newTime;
            }
    
            
        }
    }
