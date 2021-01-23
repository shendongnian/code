	<Page.Resources>
		<Storyboard x:Name="OpenSettings">
			<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.ScaleY)" Storyboard.TargetName="SettingGrid">
				<EasingDoubleKeyFrame KeyTime="0" Value="0"/>
				<EasingDoubleKeyFrame KeyTime="0:0:1" Value="1"/>
			</DoubleAnimationUsingKeyFrames>
			<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="SettingGrid">
				<EasingDoubleKeyFrame KeyTime="0" Value="0"/>
				<EasingDoubleKeyFrame KeyTime="0:0:1" Value="1"/>
			</DoubleAnimationUsingKeyFrames>
		</Storyboard>
	</Page.Resources>
    <Grid x:Name="SettingGrid" Background="{StaticResource ApplicationPageBackgroundThemeBrush}" RenderTransformOrigin="0.5,0.5">
    	<Grid.RenderTransform>
    		<CompositeTransform/>
    	</Grid.RenderTransform>
    </Grid>
