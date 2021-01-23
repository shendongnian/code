    <ItemsControl ItemsSource="{Binding GridCellViewModelCollection}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid IsItemsHost="True">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition/>
                        <RowDefinition/>
                        <RowDefinition/>
                        <RowDefinition/>
                    </Grid.RowDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Setter Property="Grid.Column" Value="{Binding ColumnKey}"/>
                <Setter Property="Grid.Row" Value="{Binding RowKey}"/>
            </Style>
        </ItemsControl.ItemContainerStyle>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding CellText}"/>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
