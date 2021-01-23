    <GridView x:Name="myGridView" Grid.Row="1" ItemsSource="{Binding CardsCollection, Mode=TwoWay}">
         <GridView.ItemTemplate>
             <DataTemplate>
                 <Grid>
                      <Button Height="258" Width="180" Content="{Binding}" Margin="0,0,0,0" 
                              Command="{Binding ElementName=myGridView,
                       Path=DataContext.PickCardCommand}" CommandParameter="{Binding}">
                          <Button.Template>
                              <ControlTemplate>
                                  <StackPanel Orientation="Vertical">
                                      <Border BorderThickness="2" BorderBrush="White" Height="258" Width="180">
                                          <Border.Background>
                                              <ImageBrush ImageSource="{Binding BackgroundImage}" />
                                          </Border.Background>
                                       </Border>
                                  </StackPanel>
                              </ControlTemplate>
                           </Button.Template>
                       </Button>
                   </Grid>
               </DataTemplate>
           </GridView.ItemTemplate>
       </GridView>
