    <ControlTemplate.Triggers>
        <Trigger Property="IsMouseOver" Value="true">
            <Trigger.EnterActions>
                <BeginStoryboard Name="EnlargeThumb">
                    <Storyboard TargetName="canvas" 
                                TargetProperty="RenderTransform.Children[1].ScaleX" >
                        <DoubleAnimation To="2" Duration="0:0:0" />
                    </Storyboard>
                </BeginStoryboard>
            </Trigger.EnterActions>
			<Trigger.ExitActions>
				<StopStoryboard BeginStoryboardName="EnlargeThumb" />
			</Trigger.ExitActions>
       </Trigger>
