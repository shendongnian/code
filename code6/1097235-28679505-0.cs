    <DataGrid Grid.Row="1" ItemsSource="{Binding Comms.View}" RowHeaderTemplate="{StaticResource TableRowTemplate}"
                  HorizontalGridLinesBrush="#FFC9CACA" VerticalGridLinesBrush="#FFC9CACA" RowHeaderWidth="50" AutoGenerateColumns="False" >
            <DataGrid.Columns>
                <DataGridComboBoxColumn x:Name="CommTypeComboBoxColumn" Header="Type" 
                                        SelectedValuePath="CommTypeId" SelectedValueBinding="{Binding CommTypeId}">
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding Path=CommTypes.View}" />
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle>
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding Path=CommTypes.View}" />
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                </DataGridComboBoxColumn>
                <DataGridTextColumn Header="Waarde" Binding="{Binding CommValue,UpdateSourceTrigger=PropertyChanged}" Width="*"/>
            </DataGrid.Columns>
        </DataGrid>
