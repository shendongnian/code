    <Grid>
        <Grid.Resources>
            <!--Data context for the whole Grid-->
            <myNamespace:ServiceCollectionViewModel x:Key="MyViewModel" />
        </Grid.Resources>
        <TreeView Name="ServiceTree"
                  DataContext="{StaticResource MyViewModel}"
                  ItemsSource="{Binding ServiceModels}">
            <TreeView.Resources>
                
                <!--Implicit style for TreeViewItem, IsExpanded and IsSelected have no binding because 
                they are not used by view-models-->
                <Style TargetType="{x:Type TreeViewItem}">
                    <Setter Property="FontWeight" Value="Normal" />
                    <Style.Triggers>
                        <Trigger Property="IsSelected" Value="True">
                            <Setter Property="FontWeight" Value="Bold" />
                        </Trigger>
                    </Style.Triggers>
                </Style>
                
                <!--Template for the first level items-->
                <HierarchicalDataTemplate DataType="{x:Type myNamespace:ServiceModel}" ItemsSource="{Binding Messages}">
                    <TextBlock Text="{Binding Name}"/>
                </HierarchicalDataTemplate>
                <!--Template for the second level, due to the fact that String is not hierarchical
                regular DataTemplate is enough-->
                <DataTemplate DataType="{x:Type system:String}">
                    <TextBlock Text="{Binding}"/>
                </DataTemplate>
                
            </TreeView.Resources>
        </TreeView>
    </Grid>
