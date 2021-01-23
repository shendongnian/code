    <Window x:Class="WpfApplication14.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:local="clr-namespace:WpfApplication14"
            Title="MainWindow" Height="350" Width="525">
        <ListView ItemsSource="{Binding}">
            <ListView.ItemContainerStyle>
                <Style TargetType="ListViewItem">
                    <Setter Property="IsSelected" Value="{Binding IsSelected}"/>
                </Style>
            </ListView.ItemContainerStyle>
            
            <ListView.View>
                <GridView>
                    <GridViewColumn>
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <CheckBox IsChecked="{Binding IsSelected}"/>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Name" DisplayMemberBinding="{Binding Name}"/>
                    <GridViewColumn Header="Size">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock x:Name="Size" Text="{Binding Size}"/>
                                <DataTemplate.Triggers>
                                    <DataTrigger Binding="{Binding IsFile}" Value="False">
                                        <Setter TargetName="Size" Property="Text" Value="[Directory]"/>
                                    </DataTrigger>
                                </DataTemplate.Triggers>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Path" DisplayMemberBinding="{Binding Path}"/>
                </GridView>
            </ListView.View>
        </ListView>
    </Window>
