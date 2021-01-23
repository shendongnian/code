    <TreeView x:Name="tree" Width="500" Height="200"
              VerticalAlignment="Top" HorizontalAlignment="Center"
              >
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding Children}">
                    <HierarchicalDataTemplate.ItemContainerStyle>                       
                        <Style >
                            <Setter Property="TreeViewItem.IsExpanded" Value="{Binding IsExpanded, Mode=TwoWay}" />
                            <Setter Property="TreeViewItem.IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding IsQuery}" Value="true">
                                    <Setter Property="TreeViewItem.Foreground" Value="Chartreuse" />
                                </DataTrigger>
                                <DataTrigger Binding="{Binding IsFolder}" Value="true">
                                    <Setter Property="TreeViewItem.Foreground" Value="Crimson" />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </HierarchicalDataTemplate.ItemContainerStyle>
                    <TextBlock Text="{Binding NodeName}"/>
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
