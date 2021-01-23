    <!-- somewhere in Resources -->
    <Style x:Key="ReusableItemContainerStyle" TargetType="ContentControl">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="ContentControl">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="10"/>
                            <ColumnDefinition Width="*"/>
                        </Grid.ColumnDefinitions>
                        <Path Grid.Column="0"/>
                        <ContentPresenter Grid.Column="1"/>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    <local:MyItemsControl ItemsSource="{Binding MyItems}"
        ItemContainerStyle="{StaticResource ReusableItemContainerStyle}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <c:MyControl />
                    <c:MyButton />
                </StackPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </local:MyItemsControl>
