    <ItemsControl ItemsSource="{Binding MyCollection}">
        <ItemsControl.Resources>
            <Style TargetType="ContentPresenter">
                <Setter Property="Canvas.Left"
                        Value="{Binding Position.X}" />
                <Setter Property="Canvas.Top"
                        Value="{Binding Position.Y}" />
                <Setter Property="RenderTransform">
                    <Setter.Value>
                        <RotateTransform Angle="{Binding Orientation}" />
                    </Setter.Value>
                </Setter>
            </Style>
        </ItemsControl.Resources>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <local:ItemView />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
