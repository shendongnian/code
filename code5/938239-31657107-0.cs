    <ControlTemplate TargetType="{x:Type ScrollBar}">
	<Grid SnapsToDevicePixels="true">
		<Grid.RowDefinitions>
			<RowDefinition MaxHeight="18"/>
			<RowDefinition Height="0.00001*"/>
			<RowDefinition MaxHeight="18"/>
		</Grid.RowDefinitions>
		<RepeatButton Grid.Row="0" Height="18" Command="{x:Static ScrollBar.LineUpCommand}" />
		<Track x:Name="PART_Track" Grid.Row="1" IsDirectionReversed="true" IsEnabled="{TemplateBinding IsMouseOver}">
			<Track.DecreaseRepeatButton>
				<RepeatButton Command="{x:Static ScrollBar.PageUpCommand}" Style="..."/>
			</Track.DecreaseRepeatButton>
			<Track.IncreaseRepeatButton>
				<RepeatButton Command="{x:Static ScrollBar.PageDownCommand}" Style="..."/>
			</Track.IncreaseRepeatButton>
			<Track.Thumb>
				<Thumb Style="..." Width="14"/>
			</Track.Thumb>
		</Track>
		<RepeatButton Grid.Row="2" Height="18" Command="{x:Static ScrollBar.LineDownCommand}" />
	</Grid>
