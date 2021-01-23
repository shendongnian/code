                <Rectangle Name="imageRect" Grid.Column="0" Fill="{StaticResource PhoneForegroundBrush}" Margin="4,8,0,2" Width="48" Height="48" VerticalAlignment="Center" Opacity="0">
                        <Rectangle.Resources>
                            <EventTrigger x:Name="event" RoutedEvent="Rectangle.Loaded">
                                <EventTrigger.Actions>
                                    <BeginStoryboard>
                                        <Storyboard x:Name="mystoryboard">
                                            <DoubleAnimation Storyboard.TargetName="imageRect" Storyboard.TargetProperty="Opacity" From="0.0" To="1.0" Duration="0:0:0.5" />
                                        </Storyboard>
                                    </BeginStoryboard>
                                </EventTrigger.Actions>
                            </EventTrigger>
                        </Rectangle.Resources>
                        <Rectangle.OpacityMask>
                            <ImageBrush ImageSource="{Binding itemIcon}" />
                        </Rectangle.OpacityMask>
                    </Rectangle>
