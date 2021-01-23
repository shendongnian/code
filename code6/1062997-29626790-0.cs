                <mui:ModernTab.Style>
                <Style>
                    <Style.Triggers>
                        <Trigger Property="mui:ModernTab.Layout" Value="List">
                            <Trigger.Setters>
                                <Setter Property="Control.Template">
                                    <Setter.Value>
                                        <ControlTemplate TargetType="{x:Type mui:ModernTab}">
                                            <Grid>
                                                <Grid.ColumnDefinitions>
                                                    <ColumnDefinition Width="Auto"/>
                                                    <ColumnDefinition Width="9"/>
                                                    <ColumnDefinition/>
                                                </Grid.ColumnDefinitions>
                                                <ListBox x:Name="LinkList" ItemsSource="{TemplateBinding mui:ModernTab.Links}"
                           ScrollViewer.HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}">
                                                    <ItemsControl.ItemTemplate>
                                                        <DataTemplate>
                                                            <TextBlock Margin="10,2,2,2" FontSize="{DynamicResource SmallFontSize}" TextTrimming="CharacterEllipsis"
                                   Text="{Binding DisplayName, Converter={StaticResource ToUpperConverter}}"/>
                                                        </DataTemplate>
                                                    </ItemsControl.ItemTemplate>
                                                </ListBox>
                                                <Rectangle Grid.Column="1" Fill="{DynamicResource SeparatorBackground}" Width="1" HorizontalAlignment="Center"
                             VerticalAlignment="Stretch"/>
                                                <mui:ModernFrame Grid.Column="2" ContentLoader="{TemplateBinding mui:ModernTab.ContentLoader}"
                                        Margin="32,0,0,0"
                                        Source="{Binding SelectedSource, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}"/>
                                            </Grid>
                                        </ControlTemplate>
                                    </Setter.Value>
                                </Setter>
                            </Trigger.Setters>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </mui:ModernTab.Style>
