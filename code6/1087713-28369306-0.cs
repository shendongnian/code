    <Window x:Class="DataTemplateSelector_Learning.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:DataTemplateSelector_Learning"
        Title="MainWindow" Height="350" Width="525">
    <Window.Resources>
        <DataTemplate x:Key="GroupNumber">
            <TextBlock Text="{Binding Number}"/>
        </DataTemplate>
        <DataTemplate x:Key="GroupUnit">
            <TextBlock Text="{Binding Unit}" />
        </DataTemplate>
    </Window.Resources>
    <StackPanel>
        <DataGrid DockPanel.Dock="Top"
                  AutoGenerateColumns="False"
                  CanUserAddRows="False"
                  CanUserDeleteRows="False"
                  CanUserReorderColumns="False"                  
                  Name="numGrid">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="GroupNumber">
                    <DataGridTemplateColumn.CellTemplateSelector>
                        <local:GroupTemplateSelector 
                            GroupNumber="{StaticResource GroupNumber}"
                            GroupUnit="{StaticResource GroupUnit}"/>
                    </DataGridTemplateColumn.CellTemplateSelector>
                </DataGridTemplateColumn>
                <DataGridTextColumn Header="Text"
                                    Binding="{Binding Text}" />
                <DataGridTextColumn Header="Comment"
                                    Binding="{Binding Comment}" />
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Button Content="Delete" />
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
        <DataGrid DockPanel.Dock="Top"
                  AutoGenerateColumns="False"
                  CanUserAddRows="False"
                  CanUserDeleteRows="False"
                  CanUserReorderColumns="False"                  
                  Name="unitGrid">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="GroupUnit">
                    <DataGridTemplateColumn.CellTemplateSelector>
                        <local:GroupTemplateSelector 
                            GroupNumber="{StaticResource GroupNumber}"
                            GroupUnit="{StaticResource GroupUnit}"/>
                    </DataGridTemplateColumn.CellTemplateSelector>
                </DataGridTemplateColumn>
                <DataGridTextColumn Header="Text"
                                    Binding="{Binding Text}" />
                <DataGridTextColumn Header="Comment"
                                    Binding="{Binding Comment}" />
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Button Content="Delete" />
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </StackPanel>
