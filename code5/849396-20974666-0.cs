     <Grid>
            <Grid.RowDefinitions>
                <RowDefinition/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <ItemsControl Grid.Column="0"  ItemsSource="{Binding Title}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <TextBox Text="{Binding .}" Width="200" HorizontalAlignment="Left" />
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
        <ItemsControl  Grid.Column="1" ItemsSource="{Binding Question}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <TextBox Text="{Binding .}" Width="200" HorizontalAlignment="Left"/>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
