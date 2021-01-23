     <DataGrid.Resources>
           <ResourceDictionary>
              <ResourceDictionary.MergedDictionaries>
                   <ResourceDictionary Source="MyDefaultPreferences.xaml"/>
              </ResourceDictionary.MergedDictionaries>              
           </ResourceDictionary>
     </DataGrid.Resources>
     ...
     <DataGrid.RowStyle>
    <Style TargetType="DataGridRow">
         <Setter property="BackgroundColor" Value="{DynamicResource NoneMsgTypeBrush}" />
         <Style.Triggers>
             <DataTrigger Binding="{Binding MsgType}" Value="1">
                 <Setter Property="BackgroundColor" Value="{DynamicResource ReadMsgTypeBrush}" />
             </DataTrigger>
             <DataTrigger Binding="{Binding MsgType}" Value="2">
                 <Setter Property="BackgroundColor" Value="{DynamicResource EditMsgTypeBrush}" />
             </DataTrigger>
             <DataTrigger Binding="{Binding MsgType}" Value="3">
                 <Setter Property="BackgroundColor" Value="{DynamicResource DeleteMsgTypeBrush}" />
             </DataTrigger>
         </Style.Triggers>
    </Style>
