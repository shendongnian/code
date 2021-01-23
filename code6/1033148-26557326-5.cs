    <local:ExtendedItemsControl ItemsSource="{Binding MyItems}">
        <local:ExtendedItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition />
                        <RowDefinition />
                        <RowDefinition />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </local:ExtendedItemsControl.ItemsPanel>
    </local:ExtendedItemsControl>
