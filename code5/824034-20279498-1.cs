    <Image >
       <Image.Style>
          <Style TargetType="{x:Type Image}">
             <Style.Triggers>
                <DataTrigger Binding="{Binding CurrentAlarmItem.AlarmCategory}" 
                             Value="Category1">
                   <Setter Property="Source" Value="{StaticResource AlarmCat1}" />
                </DataTrigger>
             </Style.Triggers>
          </Style>
       </Image.Style>
    </Image>
