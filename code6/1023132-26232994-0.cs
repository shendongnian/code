    <Grid>        
        <Grid.RowDefinitions>
            <RowDefinition />
            <RowDefinition />
        </Grid.RowDefinitions>
        
        <ListBox x:Name="MyGroupDescriptionsList" AllowDrop="True" Drop="ListBox_Drop"/>
        
        <DataGrid x:Name="MyDataGrid" Grid.Row="1" ItemsSource="{Binding}" AutoGenerateColumns="False">
            <DataGrid.ColumnHeaderStyle>
                <Style TargetType="{x:Type DataGridColumnHeader}">
                    <EventSetter Event="PreviewMouseMove" Handler="DataGridHeader_PreviewMouseMove"/>
                </Style>
            </DataGrid.ColumnHeaderStyle>
            <DataGrid.GroupStyle>
                <GroupStyle>
                    <GroupStyle.HeaderTemplate>
                        <DataTemplate>
                            <StackPanel>
                                <TextBlock Text="{Binding Name}" />
                            </StackPanel>
                        </DataTemplate>
                    </GroupStyle.HeaderTemplate>
                    <GroupStyle.ContainerStyle>
                        <Style TargetType="{x:Type GroupItem}">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate TargetType="{x:Type GroupItem}">
                                        <Expander IsExpanded="True" Header="{Binding Name}">
                                            <ItemsPresenter />
                                        </Expander>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </GroupStyle.ContainerStyle>
                </GroupStyle>
            </DataGrid.GroupStyle>
            <DataGrid.Columns>
                <DataGridTextColumn Header="A" Binding="{Binding A}"/>
                <DataGridTextColumn Header="B" Binding="{Binding B}"/>
                <DataGridTextColumn Header="C" Binding="{Binding C}"/>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
