     <DataGrid>
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ContentControl x:Name="ContentPlaceholder">
                                <ContentControl.Style>
                                    <Style TargetType="{x:Type ContentControl}">
                                        <Setter Property="ContentTemplate">
                                            <Setter.Value>
                                                <DataTemplate>
                                                    <ComboBox />
                                                </DataTemplate>
                                            </Setter.Value>
                                        </Setter>
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding COLUMNTWOPROPERTY}" Value="0">
                                                <Setter Property="ContentTemplate">
                                                    <Setter.Value>
                                                        <DataTemplate>
                                                            <TextBox Text="{Binding PROPERTYFORTEXTBOX}"/>
                                                        </DataTemplate>
                                                    </Setter.Value>
                                                </Setter>
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </ContentControl.Style>
                            </ContentControl>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
