       <ListView x:Name="ListViewUsers" ItemsSource="{Binding UserNames}" DockPanel.Dock="Top" Foreground="Green" BorderBrush="Transparent">
                        <ListView.View>
                            <GridView>
                                <GridViewColumn>
                                    <GridViewColumn.HeaderTemplate>
                                        <DataTemplate>
                                            <Button Margin="3,0,3,0" Width="30" DataContext="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}},Path=DataContext}">
                                                <Image Source="Images/Actions user group delete.ico"/>
                                            </Button>
                                        </DataTemplate>
                                    </GridViewColumn.HeaderTemplate>
                                    <GridViewColumn.CellTemplate>
                                        <DataTemplate>
                                            <Button DataContext="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Window}},Path=DataContext}">
                                                <Image Source="Images/Actions list remove user.ico" Width="25"/>
                                            </Button>
                                        </DataTemplate>
                                    </GridViewColumn.CellTemplate>
                                </GridViewColumn>
                                <GridViewColumn Header="User ID" DisplayMemberBinding="{Binding}"/>
                            </GridView>
                        </ListView.View>
                    </ListView>
