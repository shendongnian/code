	<Style x:Key="AnimatedButton" TargetType="Button">
		<Setter Property="Background" Value="Red" />
		<Style.Triggers>
			<Trigger Property="IsPressed" Value="True">
				<Trigger.EnterActions>
					<BeginStoryboard>
						<Storyboard Storyboard.TargetProperty="Background.Color">
							<ColorAnimation To="Blue" Duration="0:0:4" />
							<ColorAnimation To="Red" BeginTime="0:1:52" Duration="0:0:4" />
						</Storyboard>
					</BeginStoryboard>
				</Trigger.EnterActions>
			</Trigger>
		</Style.Triggers>
	</Style>
