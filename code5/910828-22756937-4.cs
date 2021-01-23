    <DataGridTemplateColumn.CellTemplate>
        <DataTemplate>
            <DataTemplate.Resources>
                <myns:ConvertToFormatedRuns xmlns:myns="clr-namespace:YourProjectName" />
            </DataTemplate.Resources>
            <Label>
                <Label.Content>
                    <MultiBinding Converter={StaticResource ConvertToFormatedRuns}>
                        <Binding Path="xxx" />
                        <Binding Path="yyy" />
                    </MultiBinding>
                </Label.Content>
            </Label>
        </DataTemplate>
    </DataGridTemplateColumn.CellTemplate>
     
