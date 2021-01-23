	<DataGrid AlternationCount="{x:Static system:Int32.MaxValue}">
		<DataGrid.Resources>
			<wpfApplication2:EqualsMultiConverter x:Key="EqualsMultiConverter" />
		</DataGrid.Resources>
		<DataGrid.RowStyle>
			<Style TargetType="{x:Type DataGridRow}">
				<Style.Triggers>
					<DataTrigger Value="True">
						<DataTrigger.Binding>
							<MultiBinding Converter="{StaticResource EqualsMultiConverter}">
								<Binding Path="(ItemsControl.AlternationIndex)" RelativeSource="{RelativeSource Self}" />
								<Binding Path="ViewModelPropertyBoundToNumericUpDown" />
							</MultiBinding>
						</DataTrigger.Binding>
						
						<Setter Property="Background" Value="#CCC" />
					</DataTrigger>
				</Style.Triggers>
			</Style>
		</DataGrid.RowStyle>
	</DataGrid>
