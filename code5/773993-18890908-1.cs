     <ToggleButton>
         <ToggleButton.Content>
             <Image>
                <Image.Style>
                    <Setter Property="Source" Value="{Binding Path="DataContext.TickImage" RelativeSource="{RelativeSource AncestorType={x:Type UserControl}}"/>
                     <Style.Triggers>
                          <DataTrigger Binding="{Binding IsPressed, RelativeSource="{RelativeSource AncestorType={x:Type ToggleButton}}" Value="true">
                             <Setter Property="Source" Value="{Binding Path="DataContext.CrossImage" RelativeSource="{RelativeSource AncestorType={x:Type UserControl}}"/>
                          </DataTrigger>
                      </Style.Triggers>
                 </Image.Style>
                </Image>
              </ToggleButton.Content> 
            </ToggleButton>
