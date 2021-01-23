    You can make a bool property and to bind the visibility button to it, like this:
        bool IsVisible { get; set; } //Code behind
    And in xaml:
        <!-- Pay attention: The Converter is still not written, follow next steps -->
        <Button x:Name="DeleteButton" 
                Content="Delete"
                HorizontalAlignment="Left" Height="64" Margin="74,579,0,-9" 
                VerticalAlignment="Top" Width="314" FontSize="24" 
                Visibility="{Binding IsVisible, 
                             Converter={StaticResource BooleanToVisibilityConverter}}" />
    The converter:
        public class BooleanToVisibilityConverter : IValueConverter
        {
            /// <summary>
            /// Converts a value.
            /// </summary>
            /// <param name="value">The value produced by the binding source.</param>
            /// <param name="targetType">The type of the binding target property.</param>
            /// <param name="parameter">The converter parameter to use.</param>
            /// <param name="culture">The culture to use in the converter.</param>
            /// <returns>A converted value. Returns Visible if the value is true; otherwise, collapsed.</returns>
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }
            public object ConvertBack(object value, Type targetType, object parameter,CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    And at the resources in xaml you should add the converter so you can access it with the StaticResource:
        <Application
        x:Class="UI.App"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:converters="using:UI.Converters">
        <converters:BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter" />
    And then to change the IsVisible property for your need, if true it will be bound to   Visible, if false, it will be collapsed.
        if (condition)
        {
            IsVisible = true;
        }
    For more information you should learn: [binding][1], [converters][2].
