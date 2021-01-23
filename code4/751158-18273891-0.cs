    <BitmapImage x:Key="RotationImage0" UriSource="Images\rotation\0.png">
        <BitmapImage.RenderTransform>
            <RotateTransform x:Name="RotateTransform" CenterX="50" CenterY="50" Angle="0" />
        </BitmapImage.RenderTransform>
    </BitmapImage>
    <BitmapImage.Style>
        <Style>
            <Style.Triggers>
                <DataTrigger Binding="{Binding IsLoading, Mode=OneWay}" Value="True">
                    <Setter Property="Control.Visibility" Value="Visible" />
                    <DataTrigger.EnterActions>
                        <StopStoryboard BeginStoryboardName="ReverseRotationStoryboard" />
                        <BeginStoryboard Name="RotationStoryboard">
                            <Storyboard RepeatBehavior="Forever">
                                <DoubleAnimation Storyboard.TargetProperty="RenderTransform.
    (RotateTransform.Angle)" From="0" To="360" Duration="0:0:2.0" />
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.EnterActions>
                    <DataTrigger.ExitActions>
                        <StopStoryboard BeginStoryboardName="RotationStoryboard" />
                        <BeginStoryboard Name="ReverseRotationStoryboard">
                            <Storyboard RepeatBehavior="Forever">
                                <DoubleAnimation Storyboard.TargetProperty="RenderTransform.
    (RotateTransform.Angle)" From="360" To="0" Duration="0:0:2.0" />
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.ExitActions>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </BitmapImage.Style>
