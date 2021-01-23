    <TreeView x:Name="..." ItemsSource="{Binding RootNode}">
        <TreeView.ItemContainerStyle>
            <Style TargetType="{x:Type TreeViewItem}">
                <!-- Items in the ItemsSource need to have these properties for the binding to work -->
                <Setter Property="IsExpanded" Value="{Binding IsExpanded, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
                <!-- You can also optionally change some style values based on IsSelected and IsExpanded values -->
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsSelected}" Value="True">
                        <Setter Property="BorderThickness" Value="4 0 0 1"/>
                        <Setter Property="BorderBrush" Value="DeepSkyBlue"/>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding IsSelected}" Value="False">
                        <Setter Property="BorderThickness" Value="4 0 0 1 "/>
                        <Setter Property="BorderBrush" Value="Transparent"/>
                    </DataTrigger>
                </Style.Triggers>
             </Style>
         </TreeView.ItemContainerStyle>
         <TreeView.Resources>
            <HierarchicalDataTemplate>
                 ...
            </HierarchicalDataTemplate>
         </TreeView.Resources>
    </TreeView>
