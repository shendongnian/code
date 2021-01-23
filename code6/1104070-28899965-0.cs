    <DataGrid x:Name="Dg" ItemsSource="{Binding YourCollection}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridCheckBoxColumn x:Name="DgCheckBoxColumn" Visibility="Collapsed" Width="30" Binding="{Binding B.IsAvailable, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" IsReadOnly="False"/>
            <DataGridTextColumn Header="Id" Binding="{Binding B.Id}" IsReadOnly="True"/>
            <DataGridTextColumn Header="Title" Binding="{Binding B.Title}" IsReadOnly="True"/>
            <DataGridTextColumn Header="Type" Binding="{Binding B.Type}" IsReadOnly="True"/>
        </DataGrid.Columns>
    </DataGrid>
