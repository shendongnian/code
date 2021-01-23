    <DataGrid.Resources>
       <ResourceDictionary>
           <ResourceDictionary.MergedDictionaries>
               <ResourceDictionary Source="pack://application:,,,/MahApps.Metro;component/Styles/controls.datagrid.xaml"/>
           </ResourceDictionary.MergedDictionaries>           
           <Style TargetType="{x:Type DataGridColumnHeader}" BasedOn="{StaticResource MetroDataGridColumnHeader}">
               <Setter Property="FontWeight" Value="SemiBold"/>
               <Setter Property="ContentTemplate" Value="{x:Null}"/>
           </Style>
       </ResourceDictionary>
    </DataGrid.Resources>
