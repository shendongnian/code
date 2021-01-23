     <DataGrid x:Name="dataGrid"  AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Id" Binding="{Binding Id}"></DataGridTextColumn>
                <DataGridTextColumn Header="Humidity" SortMemberPath="Humidity">
                    <DataGridTextColumn.Binding>
                        <MultiBinding Converter="{StaticResource multiDataValueConverter}">
                            <Binding Path="Humidity" />
                            <Binding Path="Version" />
                        </MultiBinding>
                    </DataGridTextColumn.Binding>
                </DataGridTextColumn>
