Storyboard
    <Storyboard x:Name="FadingFeedback" x:Key="FadingFeedback"> 
        <DoubleAnimation Storyboard.TargetProperty="Opacity" From="0.5" 
                                 To="0" BeginTime="0:0:0" Duration="0:0:2.0">
                
            <DoubleAnimation.EasingFunction>
                <ExponentialEase Exponent="10" EasingMode="EaseIn" />
            </DoubleAnimation.EasingFunction>
        </DoubleAnimation>
        <ObjectAnimationUsingKeyFrames BeginTime="0:0:2.0" Storyboard.TargetProperty="(Popup.IsOpen)">
            <DiscreteObjectKeyFrame KeyTime="0:0:0">
                <DiscreteObjectKeyFrame.Value>
                    <sys:Boolean>False</sys:Boolean>
                </DiscreteObjectKeyFrame.Value>
            </DiscreteObjectKeyFrame>
        </ObjectAnimationUsingKeyFrames>
    </Storyboard>
	
    <Popup Name="popup" Placement="Center" PopupAnimation="Fade" AllowsTransparency="True" IsOpen="{Binding DoShowMessage}">
        <Popup.Style>
            <Style>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding DoShowMessage}" Value="True">
                    <!--<Setter Property="Popup.IsOpen" Value="True" />--> <!-- not necessarily, because we have Popup.IsOpen = True -->
                            
                        <DataTrigger.EnterActions>
                            <BeginStoryboard Storyboard="{StaticResource FadingFeedback}" />
                        </DataTrigger.EnterActions>
                    </DataTrigger>
                </Style.Triggers>
                </Style>
        </Popup.Style>	
		...
    </Popup>		
