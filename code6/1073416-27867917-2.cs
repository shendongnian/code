    <Style x:Key="TextBox" TargetType="{x:Type TextBox}">
      <Style.Triggers>
    <Trigger Property="Validation.HasError" Value="true">
      <Setter Property="ToolTip">
		<Setter.Value>
			<MultiBinding Converter="{StaticResource Converter}">
				<MultiBinding.Bindings>
					<Binding RelativeSource="{RelativeSource Self}" />
					<Binding RelativeSource="{x:Static RelativeSource.Self}" Path="(Validation.Errors)[0].ErrorContent" />
				</MultiBinding.Bindings>
			</MultiBinding>
		</Setter.Value>
	  </Setter>
    </Trigger>
    </Style.Triggers>
    </Style>
