     <ListView x:Name="lw" ItemsSource="{Binding DroppedItems}">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="MouseDoubleClick">
                    <Custom:EventToCommand Command="{Binding DataContext.RenameItemCommand, ElementName=lw}"/>
                </i:EventTrigger>
             </i:Interaction.Triggers>
    
             <ListView.ItemTemplate >
                <DataTemplate >
                    <Label Content="{Binding Field}" />
                </DataTemplate>
             </ListView.ItemTemplate>
    </ListView>
