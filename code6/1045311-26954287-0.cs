    <Style TargetType="ToolTip">
       <Style.Resources>
          <local:ElementToTypeConverter x:Key="typeConverter"/>
       </Style.Resources>
       <Style.Triggers>
           <DataTrigger Binding="{Binding PlacementTarget, 
                                  RelativeSource={RelativeSource Self},
                                  Converter={StaticResource typeConverter}}" 
                        Value="{x:Type Button}">
               <Setter Property="Template">
                  <Setter.Value>
                     <ControlTemplate TargetType="ToolTip">
                        <Border BorderBrush="Red" BorderThickness="2">
                          <ContentPresenter/>
                        </Border>
                     </ControlTemplate>
                  </Setter.Value>
               </Setter>
           </DataTrigger>
           <DataTrigger Binding="{Binding PlacementTarget, 
                                  RelativeSource={RelativeSource Self},
                                  Converter={StaticResource typeConverter}}" 
                        Value="{x:Type ToggleButton}">
               <Setter Property="Template">
                  <Setter.Value>
                     <ControlTemplate TargetType="ToolTip">
                        <Border BorderBrush="Blue" BorderThickness="1">
                           <ContentPresenter/>
                        </Border>
                     </ControlTemplate>
                  </Setter.Value>
               </Setter>
           </DataTrigger>
       </Style.Triggers>
    </Style>
