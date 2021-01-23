    <Style TargetType="{x:Type ListViewItem}" x:Key="ComponentInVehicleListView" BasedOn="{StaticResource ListViewItemBASE}">
            <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
            <Setter Property="ContentTemplate">
                <Setter.Value>
                    <DataTemplate>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="auto"/>
                                <ColumnDefinition Width="auto"/>
                                <ColumnDefinition Width="auto" SharedSizeGroup="ButtonsColumn"/>
                            </Grid.ColumnDefinitions>
                                <TextBlock Text="{Binding ArticleID}"
                                           Grid.Column="0"
                                           />
                            <TextBlock Text="{Binding ArticleName}"
                                       Grid.Column="1"
                                       />
                            <Button Command="{Binding Remove, RelativeSource={RelativeSource AncestorType=Grid}}"
                                                Grid.Column="2"
                                                >
                                <Button.Content>
                                    <StackPanel Style="{StaticResource IconTextCombo}">
                                        <Image Source="{StaticResource Img}"/>
                                    </StackPanel>
                                </Button.Content>
                            </Button>
    
                        </Grid>
                    </DataTemplate>
                </Setter.Value>
            </Setter>
