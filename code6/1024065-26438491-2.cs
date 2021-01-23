    <Window x:Class="WpfApplication3.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="600" Width="640">
    <Grid>
        <ItemsControl ItemsSource="{Binding Groups}" HorizontalAlignment="Center">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <WrapPanel></WrapPanel>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding Name}" Margin="4"/>
                        <TabControl Width="300" MinHeight="250" Margin="4" ItemsSource="{Binding Tabs}">
                            <TabControl.ItemTemplate>
                                <DataTemplate>
                                    <TextBlock Text="{Binding Name}"/>
                                </DataTemplate>
                            </TabControl.ItemTemplate>
                            <TabControl.ContentTemplate>
                                <DataTemplate>
                                    <ListBox ItemsSource="{Binding Tests}">
                                        <ListBox.ItemTemplate>
                                            <DataTemplate>
                                                <CheckBox Content="{Binding Name}" IsChecked="{Binding IsEnabled}"/>
                                            </DataTemplate>
                                        </ListBox.ItemTemplate>
                                    </ListBox>
                                </DataTemplate>
                            </TabControl.ContentTemplate>
                        </TabControl>
                    </StackPanel>
                </DataTemplate>
            </ItemsControl.ItemTemplate>
        </ItemsControl>
    </Grid>
