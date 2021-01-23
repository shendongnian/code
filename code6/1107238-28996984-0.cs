    <ItemsControl ItemsSource="{StaticResource data}" Grid.IsSharedSizeScope="True">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <WrapPanel></WrapPanel>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto" SharedSizeGroup="ColumnSize" />
                    </Grid.ColumnDefinitions>
                    <Border Margin="5" BorderThickness="1" BorderBrush="Black">
                        <TextBlock Text="{Binding}"></TextBlock>
                    </Border>
                </Grid>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
