                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text={Binding}>
                                <TextBlock.ContextMenu>
                                    <ContextMenu>
                                        <MenuItem Header="Copy"/>
                                        <MenuItem Header="Paste"/>
                                        <MenuItem Header="Clear"/>
                                    </ContextMenu>
                                </TextBlock.ContextMenu>
                            </TextBlock>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
