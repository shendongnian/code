    <ListView x:Name="ItemsFromStash" 
              ItemsSource="{Binding DropBox.DroppedItems}" ItemTemplate="{DynamicResource DropItemTemplate}"
              SelectedItem="{Binding DropBox.SelectedDropItem}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="MouseLeftButtonUp">
                            <Custom:EventToCommand Command="{Binding DropBox.RenameItemCommand, Mode=OneWay}"/>
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                    <!-- Place your template controls here -->
                </Grid>                                        
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
