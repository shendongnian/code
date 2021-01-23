    <Style TargetType="{x:Type l:NodeView}">
        <Setter Property="ContentTemplate">
            <Setter.Value>
                <DataTemplate TargetType="{x:Type l:NodeView}">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="18" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="Auto" />
                        </Grid.RowDefinitions>
                        <TextBlock Text="{Binding Name}"
                                   Grid.Column="1" />
                        <ItemsControl Grid.Row="1" Grid.Column="1"
                                      ItemsSource="{Binding Children}">
                            <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                    <l:NodeView Content="{Binding}"/>
                                </DataTemplate>
                            </ItemsControl.ItemTemplate>
                        </ItemsControl>
                    </Grid>
                </DataTemplate>
            </Setter.Value>
        </Setter>
    </Style>
