    <Window.Resources>
        <ViewModels:ViewModel x:Key="ViewDataContext"/>
    </Window.Resources>
    <!-- Here I use Static resource as Data context -->
    <Grid DataContext="{Binding Source={StaticResource ResourceKey=ViewDataContext}}">
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Tipo de asociado" x:Name="TipoUsuarioSeleccionado">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Label Content="{Binding SomeElement}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                    <DataGridTemplateColumn.CellEditingTemplate>
                       <DataTemplate>
                         <!-- Again I use Static resource as Data context -->
                         <Grid Height="130" DataContext="{Binding Source={StaticResource ViewDataContext}}">
                               <Grid.RowDefinitions>
                                   <RowDefinition Height="Auto"></RowDefinition>
                                   <RowDefinition Height="*"></RowDefinition>
                               </Grid.RowDefinitions>
                               <TextBox x:Name="Filtro" Text="{Binding SomeInViewModel}"/>
                               <ListView Grid.Row="1" ItemsSource="{Binding ListaItems}">
                                  <ListView.ItemTemplate>
                                      <DataTemplate>
                                         <TextBlock Text="{Binding SomeinVM}"/>
                                      </DataTemplate>
                                  </ListView.ItemTemplate>
                               </ListView>
                         </Grid>
                    </DataTemplate>
                 </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
    </Grid>
