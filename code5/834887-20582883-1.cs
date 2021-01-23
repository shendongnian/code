    <StackPanel>
       <StackPanel.Resources>
          <Style TargetType="Button">
             <Setter Property="Template">
               <Setter.Value>
                 <ControlTemplate TargetType="Button">
                   <Border Background="{TemplateBinding Background}">
                      <ContentPresenter/>
                   </Border>
                 </ControlTemplate>
               </Setter.Value>
             </Setter>
           </Style>
        </StackPanel.Resources>
        <Button Width="100" Height="100">
          <Button.Style>
            <Style TargetType="Button"
                   BasedOn="{StaticResource {x:Type Button}}">
               <Setter Property="Background">
                 <Setter.Value>
                   <ImageBrush ImageSource="Image1.png"/>
                 </Setter.Value>
               </Setter>
               <Style.Triggers>
                 <DataTrigger Binding="{Binding IsMouseOver,
                                             RelativeSource={RelativeSource Self}}"
                              Value="True">
                    <Setter Property="Background">
                      <Setter.Value>
                        <ImageBrush ImageSource="Image2.png"/>
                      </Setter.Value>
                    </Setter>
                  </DataTrigger>
                </Style.Triggers>
             </Style>
          </Button.Style>
       </Button>
    </StackPanel>
