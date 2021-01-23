        <Window.Resources>
        <Style TargetType="{x:Type Button}" x:Key="deleteButtonStyle">
            <Setter Property="IsEnabled" Value="False"></Setter>
            <Style.Triggers>
                <DataTrigger Binding="{Binding Master}" Value="I">
                    <DataTrigger.Setters>
                        <Setter Property="IsEnabled" Value="True"></Setter>
                    </DataTrigger.Setters>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <StackPanel>
        <ListView ItemsSource="{Binding Rooms}">
            <ListView.View>
                <GridView>
                    <GridView.Columns>
                        <GridViewColumn Header="RoomName">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <Label Content="Label"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Master">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <Label Content="Label"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="MaxConnectorNum">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <Label Content="Label"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="Password">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <PasswordBox IsEnabled="{Binding IsNeedPassword }" MinWidth="100"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="EntryButton">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <Button Content="Button"/>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn Header="DeleteButton">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                    <Button Content="Button" Style="{StaticResource deleteButtonStyle}">
                                    </Button>
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView.Columns>
                </GridView>
            </ListView.View>
        </ListView>
    </StackPanel>
