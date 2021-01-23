    <DataGridTemplateColumn.CellEditingTemplate>
      <DataTemplate>
        <Grid FocusManager.FocusedElement="{Binding ElementName= taskCombo}" >
            <ComboBox x:Name="MyComboBox" Height="Auto" Width="Auto"  
            ItemsSource="{Binding Category,
                         NotifyOnTargetUpdated=True,
                         Mode=TwoWay,
                         UpdateSourceTrigger=PropertyChanged}" 
            SelectedIndex ="0"  
            SelectionChanged ="MyComboBox_SelectionChanged"/>
        </Grid>
      </DataTemplate>
    </DataGridTemplateColumn.CellEditingTemplate>
