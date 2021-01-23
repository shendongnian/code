    <ListBox ItemsSource="{Binding ObservableCollectionOfFoos}" >
        <ListBox.ItemContainerStyle >
            <Style TargetType="ListBoxItem" >
                <Setter Property="Content" Value="{Binding SomePropertyOfFoo}"/>
                <Style.Triggers>
                    <Trigger Property="IsSelected" Value="True">
                        <Setter Property="Background" Value="{Binding AnotherPropertyOfFoo}" />
                    </DataTrigger>
                </Style.Triggers>
                <Style.Resources>
                    <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" Color="Transparent" />
                    <SolidColorBrush x:Key="{x:Static SystemColors.ControlBrushKey}" Color="Transparent" />
                    <SolidColorBrush x:Key="{x:Static SystemColors.HighlightTextBrushKey}" Color="Black" />
                    <SolidColorBrush x:Key="{x:Static SystemColors.ControlTextBrushKey}" Color="Black" />
                </Style.Resources>
            </Style>
        </ListBox.ItemContainerStyle>
    </ListBox>
