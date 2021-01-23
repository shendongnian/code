        <ContextMenu Name="cm" ItemsSource="{Binding DemoInstance.ContextMenuItems}" ItemContainerStyle="{StaticResource demo2Style}" >
          <ContextMenu.Resources>
           <Style TargetType="{x:Type ContextMenu}">
             <Style.Triggers>
                <Trigger Property="HasItems" Value="False">
                  <Setter Property="Visibility" Value="Collapsed" />
                </Trigger>
             </Style.Triggers>
       
           </Style>
          </ContextMenu.Resources>
        </ContextMenu>
