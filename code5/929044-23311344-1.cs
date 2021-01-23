    <DataGrid Name="messageGrid">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Revision" Binding="{Binding Message.Revision}" />
            <DataGridTextColumn Header="Opcode" Binding="{Binding Message.Opcode}" />
            <DataGridTextColumn Header="Reason" Binding="{Binding Message.Reason}" />
            <DataGridTextColumn Header="Reaction" Binding="{Binding Message.Reaction}" />
            <DataGridTextColumn Header="Projects" Binding="{Binding Message.Projects}" />
            <DataGridTextColumn Header="Links" Binding="{Binding Message.Links}" />
            <DataGridTextColumn Header="Notes" Binding="{Binding Message.Notes}" />
        </DataGrid.Columns>
    </DataGrid>
