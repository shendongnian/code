    <Window x:Class="CareerTrackWpfClient.Views.User_Main_Window"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="User_Main_Window" Background="Black">
    <Window> 
    <Grid HorizontalAlignment="Center" Visibility="Collapsed" Name="gridbooks">
                <DataGrid Height="650" HorizontalAlignment="Stretch" Name="BooksGrid" RowHeight="90" ColumnWidth="200" 
                      ColumnHeaderHeight="40" HeadersVisibility="Column" Background="Transparent" RowBackground="DarkGray" 
                      AlternatingRowBackground="LightBlue" BorderBrush="Gray" 
                      BorderThickness="2" AutoGenerateColumns="False" >
    
                    <DataGrid.Columns>
                        <DataGridTextColumn Header="Book #" Width="220" Binding="{Binding BookID}" >
                            <DataGridTextColumn.ElementStyle>
                                <Style TargetType="TextBlock">
                                    <Setter Property="TextWrapping" Value="Wrap"/>
                                </Style>
                            </DataGridTextColumn.ElementStyle>
                            <DataGridTextColumn.EditingElementStyle>
                                <Style TargetType="TextBox">
                                    <Setter Property="Foreground" Value="Blue"/>
                                </Style>
                            </DataGridTextColumn.EditingElementStyle>
                        </DataGridTextColumn>
                        
                        <DataGridTextColumn Header="Book Title" Width="220" Binding="{Binding Title}" >
                            <DataGridTextColumn.ElementStyle>
                                <Style TargetType="TextBlock">
                                    <Setter Property="TextWrapping" Value="Wrap"/>
                                </Style>
                            </DataGridTextColumn.ElementStyle>
                            <DataGridTextColumn.EditingElementStyle>
                                <Style TargetType="TextBox">
                                    <Setter Property="Foreground" Value="Blue"/>
                                </Style>
                            </DataGridTextColumn.EditingElementStyle>
                        </DataGridTextColumn>
    </DataGrid.Columns>
                </DataGrid>
            </Grid>
