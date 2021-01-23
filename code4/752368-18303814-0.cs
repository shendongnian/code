    <TextBlock.Style>
        <Style TargetType="{x:Type TextBlock}">
            <Style.Triggers>
                <DataTrigger Binding="{Binding SystemIsReady, Mode=TwoWay, NotifyOnSourceUpdated=True}"  Value="False">
                    <DataTrigger.EnterActions>
                        <BeginStoryboard Name="FadeOut">
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetProperty="Opacity" From="1.0"  To="0.5"  Duration="0:0:1.5"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.EnterActions>
                </DataTrigger>
                <DataTrigger Binding="{Binding SystemIsReady, Mode=TwoWay, NotifyOnSourceUpdated=True}" Value="True">
                    <Setter Property="Opacity" Value="1.0"/>
                    <DataTrigger.EnterActions>
                        <StopStoryboard BeginStoryboardName="FadeOut" />
                    </DataTrigger.EnterActions>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </TextBlock.Style>
