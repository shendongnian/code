                            <Path Grid.Column="0" Data="{Binding Icon}" Width="{Binding IconWidth}" Height="{Binding IconHeight}" Fill="White" Stretch="Uniform"
                        MaxWidth="22" MaxHeight="22" MinWidth="0" MinHeight="20"/>
                            <TextBlock Grid.Column="1" Text="{Binding Title}" Foreground="White" FontSize="18" Margin="5,0,0,0" VerticalAlignment="Center">
                                <TextBlock.Triggers>
                                    <EventTrigger RoutedEvent="MouseEnter">
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <DoubleAnimation Duration="00:00:00.1" From="1" To="0.2"  Storyboard.TargetProperty="Opacity">
                                                </DoubleAnimation>
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </EventTrigger>
                                    <EventTrigger RoutedEvent="MouseLeave">
                                        <BeginStoryboard>
                                            <Storyboard>
                                                <DoubleAnimation Duration="00:00:00.1" From="0.2" To="1"  Storyboard.TargetProperty="Opacity">
                                                </DoubleAnimation>
                                            </Storyboard>
                                        </BeginStoryboard>
                                    </EventTrigger>
                                </TextBlock.Triggers>
                            </TextBlock>
                        </Grid>
                    </Button>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
