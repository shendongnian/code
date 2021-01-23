    <ContextMenu Name="cm" ItemsSource="{Binding DemoInstance.ContextMenuItems}"  
                 ItemContainerStyle="{StaticResource demo2Style}" >
      <ContextMenu.Style>
         <Style TargetType="{x:Type ContextMenu}">
            <Style.Triggers>
               <Trigger Property="HasItems" Value="False">
                  <Setter Property="Visibility" Value="Collapsed" />
              </Trigger>
           </Style.Triggers>
         </Style>
      </ContextMenu.Style>
    </ContextMenu>
