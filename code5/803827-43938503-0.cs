    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="30"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel Grid.Row="0" Orientation="Horizontal">
            <TextBox Text="{Binding Filter1, UpdateSourceTrigger=PropertyChanged}" Width="100"/>
            <TextBox Text="{Binding Filter2, UpdateSourceTrigger=PropertyChanged}" Width="100"/>
            <TextBox Text="{Binding Filter3, UpdateSourceTrigger=PropertyChanged}" Width="100"/>
        </StackPanel>
        <DataGrid Grid.Row="1" ItemsSource ="{Binding ItemView}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Head 1" Binding="{Binding Text1}"/>
                <DataGridTextColumn Header="Head 2" Binding="{Binding Text2}"/>
                <DataGridTextColumn Header="Head 3" Binding="{Binding Text3}"/>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
