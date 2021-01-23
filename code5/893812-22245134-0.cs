    <Storyboard x:Name="showMoreBox" AutoReverse="True" RepeatBehavior="1x" Completed="showMoreBox_Completed" FillBehavior="HoldEnd">
    	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateX)" Storyboard.TargetName="showMore">
    		<EasingDoubleKeyFrame KeyTime="0:0:0.7" Value="0">
    			<EasingDoubleKeyFrame.EasingFunction>
    				<CubicEase EasingMode="EaseOut"/>
    			</EasingDoubleKeyFrame.EasingFunction>
    		</EasingDoubleKeyFrame>
    		<EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="0"/>
    	</DoubleAnimationUsingKeyFrames>
    </Storyboard>
