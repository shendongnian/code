    ***Window.xaml***
    <Grid Margin="10">
            <StackPanel Orientation="Vertical">
                <Label Content="DataBases" Width="150" Height="50" HorizontalAlignment="Left" FontSize="20"/>
                <DataGrid Name="DgDataSource" AutoGenerateColumns="False" CanUserAddRows="False" ItemsSource="{Binding SourceData}">
                    <DataGrid.Columns>
                        <DataGridTextColumn Header="ServerName" Binding="{Binding ServerName}" Width="2*"/>
                        <DataGridTextColumn Header="SourceDatabase" Binding="{Binding SourceDatabase}" Width="2*"/>
                        <DataGridTextColumn Header="DestinationDatabase" Binding="{Binding DestinationDatabase}" Width="2*"/>
                        <DataGridTemplateColumn  Width="*" Header="Status" >
                            <DataGridTemplateColumn.CellTemplate>
                                <DataTemplate>
                                    <Button Content="{Binding Status}" Command="{Binding EnabledCommand}"></Button>
                                </DataTemplate>
                            </DataGridTemplateColumn.CellTemplate>
                        </DataGridTemplateColumn>
                    </DataGrid.Columns>
                </DataGrid>
            </StackPanel>
            
        </Grid>
