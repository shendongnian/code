        <ListView.Resources>
            <!-- Setup the context menu -->
            <ContextMenu x:Key="ItemContextMenu">
                <!-- Add menu items to the context menu -->
                <MenuItem Header="Add quantity" Command="{Binding Path=DataContext.AddQuantityCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ListView}}" />
                <MenuItem Header="Delete" Command="{Binding Path=DataContext.DeleteQuantityCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ListView}}" />
				<MenuItem Header="More Details." />
            </ContextMenu>
        </ListView.Resources>
    
        <ListView.ItemContainerStyle>
            <Style TargetType="{x:Type ListViewItem}">
                <!-- Set the context menu for the ListViewItem to be the ItemContextMenu-->
                <Setter Property="ContextMenu" Value="{StaticResource ItemContextMenu}" />
            </Style>
        </ListView.ItemContainerStyle>
    
        <ListView.View>
            <GridView>
                <GridViewColumn Width="140" Header="OrderId" DisplayMemberBinding="{Binding Path=OrderId}" />
                <GridViewColumn Width="140" Header="Name"  DisplayMemberBinding="{Binding Path=Name}" />
                <GridViewColumn Width="140" Header="Quantity" DisplayMemberBinding="{Binding Path=Quantity}" />
            </GridView>
        </ListView.View>
    
    </ListView>
