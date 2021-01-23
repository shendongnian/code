       <ListView DockPanel.Dock="Right"
              ItemsSource="{Binding}"
              SelectedItem="{Binding }"
              Name="lvMain"
              HorizontalContentAlignment="Stretch"
              >
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="auto"/>
                            <ColumnDefinition />
                            <ColumnDefinition Width="auto"/>
                        </Grid.ColumnDefinitions>
                        <TextBlock Text="{Binding ArticleID}"
                               Grid.Column="0"
                               />
                        <TextBlock Text="{Binding ArticleName}"
                           Grid.Column="1"
                           />
                        <Button Command="{Binding }"
                                    Grid.Column="2"
                                    >
                            <Button.Content>
                                <StackPanel Style="{StaticResource IconTextCombo}">
                                    <Image Source="{StaticResource img}"/>
                                </StackPanel>
                            </Button.Content>
                        </Button>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
