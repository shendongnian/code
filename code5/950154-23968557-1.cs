    <Grid>
        <Grid.Resources>
            <ObjectDataProvider x:Key="EnumerableRange"
                     xmlns:sys="clr-namespace:System;assembly=mscorlib"
                     xmlns:linq="clr-namespace:System.Linq;assembly=System.Core"
                     ObjectType="{x:Type linq:Enumerable}" MethodName="Range">
                <ObjectDataProvider.MethodParameters>
                    <sys:Int32>1</sys:Int32>
                    <sys:Int32>100</sys:Int32>
                </ObjectDataProvider.MethodParameters>
            </ObjectDataProvider>
        </Grid.Resources>
        <DataGrid AutoGenerateColumns="False" IsReadOnly="True"
                CanUserAddRows="False"
                CanUserDeleteRows="False"
                ItemsSource="{Binding Source={StaticResource EnumerableRange}}">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Test1">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <local:SampleUserControl/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <DataGridTemplateColumn Header="Test2">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <local:SampleUserControl/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
