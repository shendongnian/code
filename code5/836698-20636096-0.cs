    <Window x:Class="Binding_a_List_to_a_ComboBox.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition/>
                <RowDefinition/>
            </Grid.RowDefinitions>
    
            <ComboBox Grid.Column="0" Grid.RowSpan="2" ItemsSource="{Binding MyItemsSource, UpdateSourceTrigger=PropertyChanged}"
                      SelectedIndex="{Binding MySelectedIndex, UpdateSourceTrigger=PropertyChanged}"
                      SelectedItem="{Binding MySelectedItem, UpdateSourceTrigger=PropertyChanged}">
                <ComboBox.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition/>
                                <ColumnDefinition/>
                                <ColumnDefinition/>
                            </Grid.ColumnDefinitions>
                            <TextBlock Text="{Binding Id}" Grid.Column="0"/>
                            <TextBlock Text="{Binding Name}" Grid.Column="1"/>
                            <TextBlock Text="{Binding Otherstuff}" Grid.Column="2"/>
                        </Grid>
                    </DataTemplate>
                </ComboBox.ItemTemplate>
            </ComboBox>
            <TextBlock Text="{Binding MySelectedIndex, UpdateSourceTrigger=PropertyChanged}" Grid.Column="1" Grid.Row="0"/>
    
            <Grid  Grid.Column="1" Grid.Row="1"
                   DataContext="{Binding MySelectedItem, UpdateSourceTrigger=PropertyChanged}">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                    <ColumnDefinition/>
                </Grid.ColumnDefinitions>
            
                <TextBlock Text="{Binding Id}" Grid.Column="0"/>
                <TextBlock Text="{Binding Name}" Grid.Column="1"/>
                <TextBlock Text="{Binding Otherstuff}" Grid.Column="2"/>
            </Grid>
        </Grid>
    </Window>
