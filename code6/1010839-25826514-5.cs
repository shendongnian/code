      <Grid>
          <Grid.RowDefinitions>
              <RowDefinition Height="Auto"/>
              <RowDefinition />
          </Grid.RowDefinitions>
           <Button Content="Submit" Click="Button_Click_1"  />
           <ListView x:Name="listView_RoomList" Grid.Row="1" ItemsSource="{Binding Rooms}"
                  ScrollViewer.HorizontalScrollBarVisibility="Visible" SelectionMode="Single">
                 <ListView.View>
                       <GridView>
                          <GridView.Columns>
                             
                             <GridViewColumn>
                                <GridViewColumn.CellTemplate>
                                    <DataTemplate>
                                       <TextBlock Text="{Binding Name}"/>
                                     </DataTemplate>
                                 </GridViewColumn.CellTemplate>
                              </GridViewColumn>
                              <GridViewColumn>
                                   <GridViewColumn.CellTemplate>
                                       <DataTemplate>
                                            <PasswordBox  />
                                       </DataTemplate>
                                    </GridViewColumn.CellTemplate>
                               </GridViewColumn>                       
                        </GridView.Columns>
                   </GridView>
               </ListView.View>
           </ListView>                
      </Grid>
