        <Expander>
            <Expander.Style>
                <Style TargetType="{x:Type Expander}">
                    <Setter Property="IsExpanded" Value="True" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=MyDataGrid, Path=ItemsSource, UpdateSourceTrigger=PropertyChanged}" Value="{x:Null}">
                            <Setter Property="IsExpanded" Value="False" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Expander.Style>
            <DataGrid x:Name="MyDataGrid" ItemsSource="{Binding SomeDataSource, UpdateSourceTrigger=PropertyChanged}">
                <!-- some code -->
            </DataGrid>
        </Expander>
