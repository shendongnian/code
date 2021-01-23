    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfMVVMTextBoxCursorPosition
    {
        public class TextBoxCursorPositionBehavior : DependencyObject
        {
            public static void SetCursorPosition(DependencyObject dependencyObject, int i)
            {
                dependencyObject.SetValue(CursorPositionProperty, i);
            }
    
            public static int GetCursorPosition(DependencyObject dependencyObject)
            {
                return (int)dependencyObject.GetValue(CursorPositionProperty);
            }
    
            public static readonly DependencyProperty CursorPositionProperty =
                                               DependencyProperty.Register("CursorPosition"
                                                                           , typeof(int)
                                                                           , typeof(TextBoxCursorPositionBehavior)
                                                                           , new FrameworkPropertyMetadata(default(int))
                                                                           {
                                                                               BindsTwoWayByDefault = true
                                                                               ,DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                                                                           }
                                                                           );
    
            public static readonly DependencyProperty TrackCaretIndexProperty =
                                                        DependencyProperty.RegisterAttached(
                                                            "TrackCaretIndex",
                                                            typeof(bool),
                                                            typeof(TextBoxCursorPositionBehavior),
                                                            new UIPropertyMetadata(false
                                                                                    , OnTrackCaretIndex));
    
            public static void SetTrackCaretIndex(DependencyObject dependencyObject, bool i)
            {
                dependencyObject.SetValue(TrackCaretIndexProperty, i);
            }
    
            public static bool GetTrackCaretIndex(DependencyObject dependencyObject)
            {
                return (bool)dependencyObject.GetValue(TrackCaretIndexProperty);
            }
    
            private static void OnTrackCaretIndex(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
            {
                var textbox = dependency as TextBox;
    
                if (textbox == null)
                    return;
                bool oldValue = (bool)e.OldValue;
                bool newValue = (bool)e.NewValue;
    
                if (!oldValue && newValue) // If changed from false to true
                {
                    textbox.SelectionChanged += OnSelectionChanged;
                }
                else if (oldValue && !newValue) // If changed from true to false
                {
                    textbox.SelectionChanged -= OnSelectionChanged;
                }
            }
    
            private static void OnSelectionChanged(object sender, RoutedEventArgs e)
            {
                var textbox = sender as TextBox;
    
                if (textbox != null)
                    SetCursorPosition(textbox, textbox.CaretIndex); // dies line does nothing
            }
        }
    }
