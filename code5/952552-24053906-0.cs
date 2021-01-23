     <DataGrid ItemsSource="{Binding DataGridData}">
            <DataGrid.ColumnHeaderStyle>
                <Style TargetType="DataGridColumnHeader">
                    <Style.Setters>
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate>
                                    <Button Content="{Binding}">
                                        <Button.Style>
                                            <Style      TargetType="Button">
                                                <Setter  Property="Template">
                                                    <Setter.Value>
                                                        <ControlTemplate  TargetType="Button">
                                                            <TextBlock  TextDecorations="Underline" FontWeight="Bold">
                            <ContentPresenter  />
                                                            </TextBlock>
                                                        </ControlTemplate>
                                                    </Setter.Value>
                                                </Setter>
                                            </Style>
                                        </Button.Style>
                                    </Button>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style.Setters>
                </Style>
            </DataGrid.ColumnHeaderStyle>
        </DataGrid>
 
