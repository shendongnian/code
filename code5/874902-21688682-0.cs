    <ItemsControl Grid.Column="2" ItemsSource="{Binding Day.ItemsList, Source={StaticResource Locator}}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid Width="20"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid Height="{Binding Height}" Width="20" Margin="{Binding Margin}">
                    <Grid.Background>
                        <SolidColorBrush Opacity="{Binding Opacity}" Color="{Binding ColorHash, Converter={StaticResource HexToColorConverter}}"/>
                    </Grid.Background>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>  
