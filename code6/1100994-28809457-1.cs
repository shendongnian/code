    <Style TargetType="{x:Type ComboBox}">
        <Setter Property="IsReadOnly" Value="True" />
        <Setter Property="IsEditable" Value="False" />
        <Setter Property="ItemTemplate">
            <Setter.Value>
                <DataTemplate>
                    <TextBlock Text="{Binding}" Foreground="Black" />
                </DataTemplate>
            </Setter.Value>
        </Setter>
        <Style.Triggers>
            <Trigger Property="IsSelected" Value="True">
                <Setter Property="BorderBrush" Value="{StaticResource fokusBrush}" />
                <Setter Property="BorderThickness" Value="1.3" />
                <Setter Property="Margin" Value="2.5" />
            </Trigger>
        </Style.Triggers>
        <Style.Resources>
            <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" Color="#C2E58F" />
        </Style.Resources>
    </Style>
