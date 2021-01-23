    <clickToEdit:BoolToVisibilityConverter x:Key="VisibleIfInEditMode"/>
	<clickToEdit:BoolToVisibilityConverter x:Key="CollapsedIfInEditMode" VisibleIfTrue="False"/>
	<Style TargetType="clickToEdit:ClickToEditControl">
		<Setter Property="Template">
			<Setter.Value>
				<ControlTemplate TargetType="clickToEdit:ClickToEditControl">
					<Grid>
						<ContentPresenter
							ContentTemplate="{TemplateBinding EditTemplate}"
							Content="{Binding}"
							Visibility="{Binding IsInEditMode, RelativeSource={RelativeSource TemplatedParent}, Converter={StaticResource VisibleIfInEditMode}}"/>
						<ContentPresenter
							ContentTemplate="{TemplateBinding DisplayTemplate}"
							Content="{Binding}"
							Visibility="{Binding IsInEditMode, RelativeSource={RelativeSource TemplatedParent}, Converter={StaticResource CollapsedIfInEditMode}}"/>
					</Grid>
				</ControlTemplate>
			</Setter.Value>
		</Setter>
	</Style>
