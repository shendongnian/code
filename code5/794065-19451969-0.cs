        <DataGrid Name="m_myGrid" 
                   ItemsSource="{Binding ListOfPeople}
                   AutoGenerateColumns="True" AutoGeneratingColumn="m_grid_AutoGeneratingColumn" >
                <DataGrid.Columns>
                   <DataGridTextColumn Header="Age" /-->  <!-- This makes the thing crash -->
                </DataGrid.Columns>
         </DataGrid >
