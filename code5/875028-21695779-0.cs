    <Grid>
        <ItemsControl Grid.Column="1"
                      ItemsSource="{Binding}">
          <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
              <Grid>
                <Grid.ColumnDefinitions>
                  <ColumnDefinition Width="100" />
                  <ColumnDefinition Width="100" />
                  <ColumnDefinition Width="100" />
                </Grid.ColumnDefinitions>
              </Grid>
            </ItemsPanelTemplate>
          </ItemsControl.ItemsPanel>
    
          <ItemsControl.ItemTemplate>
            <DataTemplate>
              <!-- Those Bindings work fine -->
              <Grid Height="20"
                    Width="80"
                    Margin="{Binding Margin}">
                <Grid.Background>
                  <SolidColorBrush Color="Orange" />
                </Grid.Background>
              </Grid>
            </DataTemplate>
          </ItemsControl.ItemTemplate>
    
          <ItemsControl.ItemContainerStyle>
            <Style TargetType="FrameworkElement">
              <!-- This line only works with static numbers (0,1,2) and 
                     changes the Column of all Elements -->
              <Setter Property="Grid.Column"
                      Value="{Binding ColumnIndex}" />
            </Style>   
          </ItemsControl.ItemContainerStyle>
        </ItemsControl>
      </Grid>
