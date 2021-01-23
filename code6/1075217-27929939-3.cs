        <TreeView x:Name="Tree" ItemsSource="{Binding Account}"  Margin="-2,45,-4,-18" BorderThickness="0,0,3,0" BorderBrush="{x:Null}" MouseDoubleClick="TreeViewItem_MouseDoubleClick_1">
                <TreeView.ItemTemplate>
                    <HierarchicalDataTemplate ItemsSource="{Binding Account}" DataType="{x:Type local2:Accounts}">
                        <TextBox Text="{Binding Header}" IsReadOnly="{Binding IsReadOnly}" />
                    </HierarchicalDataTemplate>
                </TreeView.ItemTemplate>
       </TreeView>
