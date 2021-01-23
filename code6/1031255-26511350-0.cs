    <ItemsControl ItemsSource="{Binding VirtualScreens}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid ShowGridLines="True">
                    <Grid.RowDefinitions>
                        <RowDefinition />
                        <RowDefinition />
                        <RowDefinition />
                        <RowDefinition />
                        <RowDefinition />
                        <RowDefinition />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                        <ColumnDefinition />
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Name}" />
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        
        <ItemsControl.ItemContainerStyle>
            <Style>
                <Style.Setters>
                    <Setter Property="Grid.Row" Value="{Binding Row}" />
                    <Setter Property="Grid.Column" Value="{Binding Column}" />
                </Style.Setters>
            </Style>
        </ItemsControl.ItemContainerStyle>
    </ItemsControl>
