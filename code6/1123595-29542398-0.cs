    <Window x:Class="BindingListBox_Learning.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <ListBox Margin="5, 5" Background="White"  ItemsSource="{Binding SwitchAgents, UpdateSourceTrigger=PropertyChanged}" HorizontalContentAlignment="Stretch">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid Margin="3,1">
                        <Grid.ContextMenu>
                            <ContextMenu ItemsSource="{Binding ContextMenuItems}">
                                <ContextMenu.ItemContainerStyle>
                                    <Style TargetType="MenuItem">
                                        <Setter Property="Command" Value="{Binding ItemAction}"/>
                                        <Setter Property="Header" Value="{Binding ItemHeader}"/>
                                    </Style>
                                </ContextMenu.ItemContainerStyle>
                            </ContextMenu>
                        </Grid.ContextMenu>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="1*"/>
                            <ColumnDefinition Width="7*"/>
                        </Grid.ColumnDefinitions>
                        <CheckBox IsChecked="{Binding Enabled, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Margin="0,3"/>
                        <TextBlock Text="{Binding SomeProperty}" Grid.Column="1" Margin="0,2"/>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
