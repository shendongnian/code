    <telerikPrimitives:RadDataBoundListBox.ItemLoadingTemplate>
        <DataTemplate>
            <Grid MinHeight="14">
                <Grid.Triggers>
                    <EventTrigger>
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetName="ellipseTranslate" RepeatBehavior="Forever">
                                    <DoubleAnimation.EasingFunction>
                                        <SineEase EasingMode="EaseInOut" />
                                    </DoubleAnimation.EasingFunction>
                                </DoubleAnimation>
                            </Storyboard>
                        </BeginStoryboard>
                    </EventTrigger>
                </Grid.Triggers>
                <Ellipse VerticalAlignment="Center" HorizontalAlignment="Left" Width="6" Height="6" Grid.Column="1" Fill="{StaticResource PhoneAccentBrush}">
                    <Ellipse.RenderTransform>
                        <TranslateTransform x:Name="ellipseTranslate" X="0" />
                    </Ellipse.RenderTransform>
                </Ellipse>
            </Grid>
        </DataTemplate>
    </telerikPrimitives:RadDataBoundListBox.ItemLoadingTemplate>
