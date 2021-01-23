    <ListView.View>
            <GridView>
              <GridViewColumn Header="Name" Width="120">
                <GridViewColumn.CellTemplate>
                  <DataTemplate>
                    <TextBlock Text="{Binding Name}" Margin="20 0 0 0"/>
                  </DataTemplate>
                </GridViewColumn.CellTemplate>
              </GridViewColumn>
              <GridViewColumn Header="Date/ Time" Width="160" DisplayMemberBinding="{Binding Time}" />
              <GridViewColumn Header="State" Width="160" DisplayMemberBinding="{Binding State}" />
            </GridView>
          </ListView.View>
            <ListView.GroupStyle>
            <GroupStyle>
              <GroupStyle.ContainerStyle>
                <Style TargetType="{x:Type GroupItem}">
                  <Setter Property="Template">
                    <Setter.Value>
                      <ControlTemplate>
                        <Expander IsExpanded="True">
                          <Expander.Header>
                            <StackPanel Orientation="Horizontal">
                              <TextBlock Text="{Binding Name}" FontWeight="Bold" VerticalAlignment="Bottom" />
                              <TextBlock Text="{Binding ItemCount}" Foreground="Silver" FontStyle="Italic" Margin="10,0,0,0" VerticalAlignment="Bottom" />
                              <TextBlock Text=" item(s)" Foreground="Silver" FontStyle="Italic" VerticalAlignment="Bottom" />
                            </StackPanel>
                          </Expander.Header>
                          <ItemsPresenter />
                        </Expander>
                      </ControlTemplate>
                    </Setter.Value>
                  </Setter>
                </Style>
              </GroupStyle.ContainerStyle>
            </GroupStyle>
          </ListView.GroupStyle>
