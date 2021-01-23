    <ControlTemplate TargetType="{x:Type ToggleButton}">
        <Grid>
            <Ellipse Stroke="Black" />
            <Image Source="Images/PlayButton.png" Visibility="{Binding IsChecked, 
    ConverterParameter={x:Static Visibility.Hidden}, Converter={StaticResource 
    Application:BoolToVisibilityConverter}}" />
            <Image Source="Images/pauseButton.png" Visibility="{Binding IsChecked, 
    ConverterParameter={x:Static Visibility.Visible}, Converter={StaticResource 
    Application:BoolToVisibilityConverter}}" />
        </Grid>
    </ControlTemplate>
