    <DataGrid Name="DG1" AutoGenerateColumns="False" ItemsSource="{Binding}">
        <DataGrid.Columns>
            <DataGridCheckBoxColumn Header="Online Order?" IsThreeState="True" Binding="{Binding OnlineOrderFlag}" />
        </DataGrid.Columns>
    </DataGrid>
