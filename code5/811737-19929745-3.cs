    <UserControl x:Name="SystemListScreen">
            <ScrollViewer Grid.Row="1">
                    <ItemsControl x:Name="SystemList" ItemsSource="{Binding Path=Systems}">
                        <ItemsControl.ItemsPanel>
                            <ItemsPanelTemplate>
                                <UniformGrid Columns="4"/>
                            </ItemsPanelTemplate>
                        </ItemsControl.ItemsPanel>
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <Widgets:MultiLineButton 
                                    partID="{Binding ID}"
                                    company="{Binding Company}"
                                    typeSorter="{Binding Name}"
                                    typeLocation="{Binding Location}"
                                    buttonCommand="{Binding DataContext.navigateInspectList, 
                                        ElementName=SystemListScreen}"
                                    buttonCommandParameter="{Binding ItemsSource.ID, 
                                        ElementName=SystemList}"/>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
            </ScrollViewer>
    </UserControl>
