    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <StackPanel Orientation="Vertical" Loaded="StackPanel_Loaded" >
            <DataGrid Grid.Row="1" Grid.Column="1" Name="dtgTransactions" AutoGenerateColumns="False" IsReadOnly="True" Margin="10" ItemsSource="{Binding Transaction}">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="Date" Binding="{Binding Trans_Date}" />
                    <DataGridTextColumn Header="Type" Binding="{Binding Type}" />
                    <DataGridTemplateColumn Header="Dentist">
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <ItemsControl ItemsSource="{Binding Dentists}">
                                    <ItemsControl.ItemTemplate>
                                        <DataTemplate>
                                            <StackPanel Orientation="Horizontal">
                                                <TextBlock Text="{Binding Dentist_Name}"/>
                                            </StackPanel>
                                        </DataTemplate>
                                    </ItemsControl.ItemTemplate>
                                </ItemsControl>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                    </DataGridTemplateColumn>
                </DataGrid.Columns>
            </DataGrid>
        </StackPanel>
    </Window>
