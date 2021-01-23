         <telerik:RadSlideView Name="imgSlidView" SelectedItem="{Binding SelectedItem,Mode=TwoWay}" ItemsSource="{Binding Images}">
                <telerik:RadSlideView.ItemTemplate>
                    <DataTemplate>
                        <Image  Source="{Binding}">
                            <telerik:RadContextMenu.ContextMenu>
                                <telerik:RadContextMenu IsZoomEnabled="False"  OpenGesture="Tap">
                                    <telerik:RadContextMenuItem  Tap="RadContextMenuItem_Tap" Content="Share">
                                    </telerik:RadContextMenuItem>
                                </telerik:RadContextMenu>
                            </telerik:RadContextMenu.ContextMenu>
                        </Image>
                    </DataTemplate>
                </telerik:RadSlideView.ItemTemplate>
                <telerik:RadSlideView.ItemPreviewTemplate>
                    <DataTemplate>
                        <telerik:RadBusyIndicator></telerik:RadBusyIndicator>
                    </DataTemplate>
                </telerik:RadSlideView.ItemPreviewTemplate>
            </telerik:RadSlideView>
            <ListBox Grid.Row="1" ScrollViewer.HorizontalScrollBarVisibility="Auto" Name="lstImage" SelectedItem="{Binding SelectedItem,Mode=TwoWay}" ItemsSource="{Binding Images}">
                <ListBox.ItemsPanel>
                    <ItemsPanelTemplate>
                        <StackPanel Orientation="Horizontal"></StackPanel>
                    </ItemsPanelTemplate>
                </ListBox.ItemsPanel>
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <Image Height="100" Margin="0,0,5,0" Source="{Binding}">
                          
                        </Image>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
