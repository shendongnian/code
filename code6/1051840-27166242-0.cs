                                     <DataTemplate>
                                            <Grid x:Name="showGrid">
                                                <StackPanel>
                                                    <Grid Height="{Binding widthMA}" Width="{Binding widthMA}">
                                                        <Grid Margin="3.5" Background="White">                                                                
                                                            <Grid VerticalAlignment="Bottom" Background="Black" Height="30">
                                                                 <Grid.RowDefinitions>
                                                                     <RowDefinition Height="Auto"/>
                                                                     <RowDefinition Height="Auto"/>
                                                                  </Grid.RowDefinitions>
                                                                <TextBlock Text="{Binding strName}" Style="{StaticResource AlbumTitleText}" Grid.Row="0" />
                                                                <TextBlock Text="{Binding dateCreated}" Style="{StaticResource ArtistTitleText}" Grid.Row="1" />
                                                            </Grid>
                                                        </Grid>
                                                    </Grid>
                                                </StackPanel>                                                
                                            </Grid>
                                        </DataTemplate>
