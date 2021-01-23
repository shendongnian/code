    <ItemsControl>
       <ItemsControl.ItemTemplate>
          <DataTemplate>
              <TextBlock Text="SomeText">
                  <TextBlock.InputBindings>
                      <!-- See how I'm using RelativeSource to get a hold of the DataContext of the parent ItemsControl -->
                      <MouseBinding Command="{Binding DataContext.SomeCommandProperty,
                                                      RelativeSource={RelativeSource AncestorType=ItemsControl}}" 
                                    MouseAction="LeftClick" />
                  </TextBlock.InputBindings>
              </TextBlock>
          </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
