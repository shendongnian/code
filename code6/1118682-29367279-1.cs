    <Grid Background="DarkGray">
        <Grid.Resources>
            <ContextMenu x:Key="CM">
                <MenuItem Header="{Binding PlacementTarget.Tag.Header,
                                           RelativeSource={RelativeSource AncestorType=ContextMenu, Mode=FindAncestor}}"/>
            </ContextMenu>
            <HierarchicalDataTemplate  x:Key="MyTemplate">
                <TextBlock  Text="{Binding}"  
                            ContextMenu="{StaticResource CM }" 
                            Tag="{Binding DataContext,RelativeSource={RelativeSource AncestorType=TreeView, Mode=FindAncestor}}"/>
      </HierarchicalDataTemplate >
        </Grid.Resources>
        <Grid.RowDefinitions>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <TreeView Grid.Row="0" 
                  ItemTemplate="{StaticResource MyTemplate}"
                  ItemsSource="{Binding Sources}"></TreeView>
    </Grid>
