    <ControlTemplate x:Key="spinningSquareTemplate">
    			<ControlTemplate.Resources>
    				<Storyboard x:Key="OnLoaded1" RepeatBehavior="Forever">
    					<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)" Storyboard.TargetName="rectangle">
    						<EasingDoubleKeyFrame KeyTime="0:0:1" Value="360"/>
    					</DoubleAnimationUsingKeyFrames>
    				</Storyboard>
    			</ControlTemplate.Resources>
    			<Rectangle x:Name="rectangle" Fill="#FFFFB900" Stroke="Black" RenderTransformOrigin="0.5,0.5">
    				<Rectangle.RenderTransform>
    					<TransformGroup>
    						<ScaleTransform/>
    						<SkewTransform/>
    						<RotateTransform/>
    						<TranslateTransform/>
    					</TransformGroup>
    				</Rectangle.RenderTransform>
    			</Rectangle>
    			<ControlTemplate.Triggers>
    				<EventTrigger RoutedEvent="FrameworkElement.Loaded">
    					<BeginStoryboard Storyboard="{StaticResource OnLoaded1}"/>
    				</EventTrigger>
    			</ControlTemplate.Triggers>
    			
    		</ControlTemplate>
