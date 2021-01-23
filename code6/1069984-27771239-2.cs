    <DataGrid  Name="dgTasks"  HorizontalAlignment="Stretch" VerticalAlignment="Stretch" AutoGenerateColumns="False" >
         <DataGrid.Columns>
             <DataGridTextColumn Header="Task Name" Binding="{Binding TaskName}" />
             <DataGridTextColumn Header="Due Date" Binding="{Binding DueDate}"/>
             <DataGridTextColumn Header="Assigned To" Binding="{Binding AssignedTo}"/>
         </DataGrid.Columns>
     </DataGrid>
