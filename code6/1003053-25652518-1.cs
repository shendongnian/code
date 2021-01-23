    <!-- start of list for message photo thumbs -->
                                <ListBox ScrollViewer.HorizontalScrollBarVisibility="Auto"
                                         ItemSource="{Binding ThumbList}"   
                                         x:Name="FirstThumbs" />                                   
                                    <ListBox.ItemsPanel>
                                        <ItemsPanelTemplate>
                                            <StackPanel Orientation="Horizontal" />
                                        </ItemsPanelTemplate>
                                    </ListBox.ItemsPanel>
                                    <ListBox.ItemTemplate>
                                        <DataTemplate>
                                            <Grid>
                                                <Grid.ColumnDefinitions>
                                                    <ColumnDefinition />
                                                    <ColumnDefinition />
                                                </Grid.ColumnDefinitions>
                                                <Image Source="{Binding Thumb}"
                                                       Height="90" Width="90"   Stretch="UniformToFill"/>
                                                <Grid Grid.Column="1">
                                                    <Grid.RowDefinitions>
                                                    </Grid.RowDefinitions>
                                                </Grid>
                                            </Grid>
                                        </DataTemplate>
                                    </ListBox.ItemTemplate>
                                </ListBox>
                                <!-- end of list for message photo thumbs   -->     
