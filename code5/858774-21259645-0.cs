    <Viewbox>
        <ItemsControl ItemsSource="{Binding Path=Employees}">
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="3*" />
                            <ColumnDefinition Width="3*" />
                            <ColumnDefinition Width="3*" />
                        </Grid.ColumnDefinitions>
                        <Viewbox Grid.Row="0" Grid.Column="0">
                            <TextBlock Text="{Binding Path=Name}" />
                        </Viewbox>
                        <Viewbox Grid.Row="0" Grid.Column="1">
                            <TextBlock Text="{Binding Path=Surname}" />
                        </Viewbox>
                        <Viewbox Grid.Row="0" Grid.Column="2">
                            <TextBlock Text="{Binding Path=Age}" />
                        </Viewbox>
                    </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Viewbox>
