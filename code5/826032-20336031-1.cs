	<DataGridTemplateColumn Header=" Right Column ">
		<DataGridTemplateColumn.CellTemplate>
			<DataTemplate>
				<ComboBox
					ItemsSource="{Binding Caliber, RelativeSource={RelativeSource AncestorType=Window}, Mode=OneWay}"
					DisplayMemberPath="Thickness"
					SelectedItem="{Binding Selection, UpdateSourceTrigger=PropertyChanged}">
					
					<ComboBox.ItemContainerStyle>
						<Style TargetType="{x:Type ComboBoxItem}">
							<Setter Property="IsEnabled" Value="{Binding Enabled}"/>
						</Style>
					</ComboBox.ItemContainerStyle>
				</ComboBox>
			</DataTemplate>
		</DataGridTemplateColumn.CellTemplate>
	</DataGridTemplateColumn>
