            <Image Name="Spinner" Source="Resources/spinner.gif" RenderTransformOrigin="0.5, 0.5">
                <Image.Triggers>
                    <EventTrigger RoutedEvent="FrameworkElement.Loaded">
                        <EventTrigger.Actions>
                            <BeginStoryboard>
                                <Storyboard Storyboard.TargetName="Spinner" Storyboard.TargetProperty="RenderTransform.(RotateTransform.Angle)">
                                    <DoubleAnimation From="0" To="360" BeginTime="0:0:0" Duration="0:0:2" RepeatBehavior="Forever" />
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger.Actions>
                    </EventTrigger>
                </Image.Triggers>
                <Image.RenderTransform>
                    <RotateTransform Angle="0" />
                </Image.RenderTransform>
                <Image.Style>
                    <Style TargetType="Image">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding IsBusy}" Value="False">
                                <Setter Property="Visibility" Value="Hidden"/>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </Image.Style>
            </Image>
