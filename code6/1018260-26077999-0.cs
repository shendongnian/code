XAML
    <Application.Resources>
        <Style x:Key="RedButtonStyle" TargetType="{x:Type Button}">
            <Setter Property="Tag" Value="RedButton" />
            <Setter Property="Background" Value="Red" />
        </Style>
        <Style x:Key="BlueButtonStyle" TargetType="{x:Type Button}">
            <Setter Property="Tag" Value="BlueButton" />
            <Setter Property="Background" Value="Blue" />
        </Style>
    </Application.Resources>
Code behind
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        string tagValue = button.Tag.ToString();
        if (button != null)
        {
            if (tagValue == "RedButton")
            {
                button.Style = (Style)Application.Current.Resources["BlueButtonStyle"];
            }
            else if (tagValue == "BlueButton")
            {
                button.Style = (Style)Application.Current.Resources["RedButtonStyle"];
            }
        }
    }
