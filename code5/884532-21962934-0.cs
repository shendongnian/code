    <HierarchicalDataTemplate ItemsSource="{Binding InnerFiles}">    
        <HierarchicalDataTemplate.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Name}">
                    <TextBlock.ContextMenu>
                        <ContextMenu>
                            <MenuItem Name="mnuExpand" Header="Expand" 
                                Click="mnuExpand_Click" />
                        </ContextMenu>
                    </TextBlock.ContextMenu>
                 </TextBlock>
            </DataTemplate>
        </HierarchicalDataTemplate.ItemTemplate>    
    </HierarchicalDataTemplate>
