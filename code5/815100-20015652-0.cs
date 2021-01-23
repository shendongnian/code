    <Grid >
       <my:DataGrid Name="dgvPurchaseOrder"
                                 ItemsSource="{Binding}" 
                                 SelectionUnit="CellOrRowHeader"
                                 TabIndex="3">
                        <my:DataGrid.Columns>
    
                            <my:DataGridComboBoxColumn 
                                           Width="100"
                                           Header="Product Code"
                                           SelectedValueBinding="{Binding Path=Product_Id,UpdateSourceTrigger=PropertyChanged}"                                                                                       
                                           SelectedValuePath="Product_Id"
                                           DisplayMemberPath="Product_Code"                                           
                                           ItemsSource="{Binding Path=TestCollection,RelativeSource={RelativeSource FindAncestor,AncestorType={x:Type Window}}}}">
                                <my:DataGridComboBoxColumn.EditingElementStyle>
                                    <Style TargetType="ComboBox">
                                        <Setter Property="IsEditable" Value="True" />
                                    </Style>
                                </my:DataGridComboBoxColumn.EditingElementStyle>
                            </my:DataGridComboBoxColumn>
                                       .
                                       .
                                       .
                        </my:DataGrid.Columns>
                    </my:DataGrid>
    </Grid>
