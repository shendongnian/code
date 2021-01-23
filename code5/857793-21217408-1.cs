    <Style TargetType="RichTextBox">
       <Setter Property="Template">
          <Setter.Value>
             <ControlTemplate TargetType="TextBoxBase">
                <Border BorderThickness="{TemplateBinding Border.BorderThickness}"
                        BorderBrush="{TemplateBinding Border.BorderBrush}"
                        Background="{TemplateBinding Panel.Background}"
                        Name="border"
                        SnapsToDevicePixels="True">
                   <ScrollViewer HorizontalScrollBarVisibility="Hidden"
                                 VerticalScrollBarVisibility="Hidden"
                                 Name="PART_ContentHost"
                                 Focusable="False" />
                </Border>
                <ControlTemplate.Triggers>
                    <Trigger Property="UIElement.IsEnabled" Value="False">
                        <Setter Property="UIElement.Opacity" TargetName="border" 
                                Value="0.56"/>
                    </Trigger>
                <!--<Trigger Property="UIElement.IsMouseOver" Value="True">
                        <Setter Property="Border.BorderBrush" TargetName="border">
                           <Setter.Value>
                              <SolidColorBrush>#FF7EB4EA</SolidColorBrush>
                           </Setter.Value>
                        </Setter>
                    </Trigger>-->
                    <Trigger Property="UIElement.IsKeyboardFocused" Value="True">
                       <Setter Property="Border.BorderBrush" TargetName="border">
                          <Setter.Value>
                             <SolidColorBrush>#FF569DE5</SolidColorBrush>
                          </Setter.Value>
                       </Setter>
                     </Trigger>
                  </ControlTemplate.Triggers>
               </ControlTemplate>
            </Setter.Value>
         </Setter>
      </Style>
