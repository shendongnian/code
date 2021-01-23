		<ComboBox ItemsSource="{Binding SelectedMonth.Days}"
				  SelectedItem="{Binding SelectedMonth.SelectedDay}">
			<ComboBox.ItemTemplate>
				<DataTemplate>
					<TextBlock Text="{Binding Number}" x:Name="textblock"/>
					<DataTemplate.Triggers>
						<DataTrigger Binding="{Binding IsLastDayOfMonth}" Value="True">
							<Setter TargetName="textblock" Property="Visibility" Value="Collapsed"/>
						</DataTrigger>
					</DataTemplate.Triggers>
				</DataTemplate>
			</ComboBox.ItemTemplate>
		</ComboBox>
