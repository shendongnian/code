    <ListView>
             <ListView.Resources>
                 <ContextMenu x:Key="initial">
                     <Menu>
                         <MenuItem Header="First Option"></MenuItem>
                     </Menu>
                 </ContextMenu>
                 <Style TargetType="ListViewItem">
                     <Style.Triggers>
                         <DataTrigger Binding="{Binding RelativeSource={RelativeSource Self}, Path=Text}" Value="1">
                             <Setter Property="ContextMenu" Value="{StaticResource initial}" />
                         </DataTrigger>
                     </Style.Triggers>
                     <Setter Property="ContextMenu" Value="{StaticResource initial}"/>
                 </Style>
             </ListView.Resources>
             <ListViewItem>1</ListViewItem>
             <ListViewItem>2</ListViewItem>
         </ListView>
