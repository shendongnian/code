    <sdk:AutoCompleteBox IsTextCompletionEnabled="True" AllowDrop="True"   ItemsSource="{Binding}"   x:Name="txtMain"  Height="25">
                    <sdk:AutoCompleteBox.ItemTemplate> 
                        <DataTemplate>
                            <sdk:TreeView   ItemsSource="{Binding YourCollection}" Name="treeView1">
                                <sdk:TreeView.ItemTemplate>
                                    <sdk:HierarchicalDataTemplate ItemsSource="{Binding YourCollection}">
                                        <TextBlock Text="{Binding Property}" />
                                        </sdk:HierarchicalDataTemplate>
                                </sdk:TreeView.ItemTemplate>
                            </sdk:TreeView>
                        </DataTemplate>
                    </sdk:AutoCompleteBox.ItemTemplate>
                </sdk:AutoCompleteBox>
