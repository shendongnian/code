     <ToggleButton>
         <ToggleButton.Content>
             <Image>
                <Image.Style>
                  <Style TargerType="Image">
                    <Setter Property="Source" Value="{Binding Path="DataContext.TickImage" RelativeSource="{RelativeSource AncestorType={x:Type UserControl}}"/>
                     <Style.Triggers>
                          <DataTrigger Binding="{Binding IsChecked, RelativeSource="{RelativeSource AncestorType={x:Type ToggleButton}}" Value="true">
                             <Setter Property="Source" Value="{Binding Path="DataContext.CrossImage" RelativeSource="{RelativeSource AncestorType={x:Type UserControl}}"/>
                          </DataTrigger>
                      </Style.Triggers>
                    </Style>
                 </Image.Style>
                </Image>
              </ToggleButton.Content> 
            </ToggleButton>
