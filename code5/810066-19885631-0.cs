    <ItemsControl x:Name="ic">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <TextBlock Text="{Binding stops}" FontSize="20" />
                    <TextBlock Text="{Binding times}" FontSize="20" Grid.Column="1" />
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
    
