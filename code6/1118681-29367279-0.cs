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
            <RowDefinition Height="Auto"/>
            <RowDefinition/>
        </Grid.RowDefinitions>
            <TextBlock HorizontalAlignment="Center">Jobs</TextBlock>
        <TreeView Grid.Row="1" ItemTemplate="{StaticResource MyTemplate}"
                  ItemsSource="{Binding Sources}"></TreeView>
    </Grid>
