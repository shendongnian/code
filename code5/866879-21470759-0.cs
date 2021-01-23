    <TextBox Name="BackUpTextBox" />
		<Button  Name="BackUpSave" Content="Save">
			<Button.Style>
				<Style TargetType="{x:Type Button}">
					<Setter Property="IsEnabled" Value="True" />
					<Style.Triggers>
						<DataTrigger Binding="{Binding ElementName=BackUpTextBox, Path=Text, UpdateSourceTrigger=PropertyChanged, Mode=OneWay}" Value="{x:Null}">
							<Setter Property="IsEnabled" Value="False" />
						</DataTrigger>
						<DataTrigger Binding="{Binding ElementName=BackUpTextBox, Path=Text, UpdateSourceTrigger=PropertyChanged, Mode=OneWay}" Value="">
							<Setter Property="IsEnabled" Value="False" />
						</DataTrigger>
					</Style.Triggers>
				</Style>
			</Button.Style>
		</Button>
