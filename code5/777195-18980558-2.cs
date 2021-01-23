    <Grid x:Name="LayoutRoot">
        <DataGridTemplateColumn Width="100">
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <Button Content="Delete" cal:Message.Attach="DeleteFromList($dataContext)" cal:Action.TargetWithoutContext="{Binding DataContext, ElementName=LayoutRoot}" />
                 </DataTemplate>
             </DataGridTemplateColumn.CellTemplate>
         </DataGridTemplateColumn>
    </Grid>
