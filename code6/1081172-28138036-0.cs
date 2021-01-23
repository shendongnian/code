    <GridViewDataColumn DataMemberBinding="{Binding IsChecked}"  >
                <GridViewDataColumn.Header >
                  <CheckBox HorizontalAlignment="Left" IsChecked="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type GridViewDataControl}}
                                                    ,Path=DataContext.CheckAll}"
                            Command="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type GridViewDataControl}}
                                                    ,Path=DataContext.CheckAllCommand}"
                            CommandParameter="{Binding RelativeSource={RelativeSource Self}, Path=IsChecked}"  />
                </GridViewDataColumn.Header>
                <GridViewDataColumn.CellTemplate>
                  <DataTemplate>
    			<StackPanel Orientation="Horizontal">
                    		<CheckBox Name="CheckBox" Padding="10" IsChecked="{Binding IsChecked}" Command="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type GridViewDataControl}}
                                                    ,Path=DataContext.ItemCommand}" CommandParameter="{Binding}"/>
                    		<TextBlock Text=y"{Binding Data}"/>
                		</StackPanel>
                  </DataTemplate>
                </GridViewDataColumn.CellTemplate>
              </GridViewDataColumn>
