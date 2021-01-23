    <MenuItem Header="_Recent Files" ItemsSource="{Binding Commands,Mode=OneWay}">
      <MenuItem.ItemContainerStyle>
        <Style TargetType="{x:Type MenuItem}">
           <Setter Property="Header" Value="{Binding Path=ShortName}" />
           <Setter Property="ToolTip" Value="{Binding Path=FileName}" />
           <Setter Property="Command" Value="{Binding Path=OpenCommand}" />
           <Setter Property="CommandParameter" Value="{Binding Path=OpenParameter}" />
           <Style.Triggers>
             <DataTrigger Binding="{Binding Path=IsSeparator}" Value="true">
               <Setter Property="MenuItem.Template">
                 <Setter.Value>
                   <ControlTemplate TargetType="{x:Type MenuItem}">
                     <Separator Style="{DynamicResource {x:Static MenuItem.SeparatorStyleKey}}"/>
                   </ControlTemplate>
                 </Setter.Value>
               </Setter>
             </DataTrigger>
           </Style.Triggers>
         </Style>
       </MenuItem.ItemContainerStyle>
     </MenuItem>
