    <TextBlock.Style>
        <Style TargetType="{x:Type TextBlock}">
            <Setter Property="Foreground" Value="#FFE8E8E8"/>
            <Style.Triggers>
                <DataTrigger Binding="{Binding HasError}" Value="True">
                    <Setter Property="Foreground" Value="Red"/>
                </DataTrigger>
                <DataTrigger Binding="{Binding HasError}" Value="False">
                    <Setter Property="Foreground" Value="#FFE8E8E8"/>
                    <DataTrigger.EnterActions>
                        <BeginStoryboard x:Name="sb">
                            <Storyboard>
                                <ObjectAnimationUsingKeyFrames BeginTime="0:0:0" Storyboard.TargetProperty="Visibility">
                                    <DiscreteObjectKeyFrame KeyTime="0">
                                        <DiscreteObjectKeyFrame.Value>
                                            <Visibility>Visible</Visibility>
                                        </DiscreteObjectKeyFrame.Value>
                                    </DiscreteObjectKeyFrame>
                                </ObjectAnimationUsingKeyFrames>
                                <DoubleAnimation BeginTime="0:0:0.0" Storyboard.TargetProperty="Opacity" From="0" To="1" Duration="0:0:0"/>
                                <DoubleAnimation BeginTime="0:0:5.0" Storyboard.TargetProperty="Opacity" From="1" To="0" Duration="0:0:0.5"/>
                                <ObjectAnimationUsingKeyFrames BeginTime="0:0:5.5" Storyboard.TargetProperty="Visibility">
                                    <DiscreteObjectKeyFrame KeyTime="0">
                                        <DiscreteObjectKeyFrame.Value>
                                            <Visibility>Hidden</Visibility>
                                        </DiscreteObjectKeyFrame.Value>
                                    </DiscreteObjectKeyFrame>
                                </ObjectAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.EnterActions>
                    <DataTrigger.ExitActions>
                        <RemoveStoryboard BeginStoryboardName="sb"/>
                    </DataTrigger.ExitActions>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </TextBlock.Style>
