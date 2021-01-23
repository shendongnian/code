       <ListView ItemsSource="{Binding Source={StaticResource  Locator},Path=EtudiantVM.ListEtudiants}">
           <ListView.View>
          <GridView>
              <GridViewColumn  Header="Nom" Width="100">
                  <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Nom}"></TextBlock>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
              </GridViewColumn>
                <GridViewColumn  Header="Prénom" Width="100">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Prenom}"></TextBlock>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn  Header="Note" Width="100">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <TextBlock Text="{Binding Note}"></TextBlock>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
