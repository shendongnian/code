    <ListView x:Name="listview1" ItemsSource="{Binding DataCollection}"  >
		<ListView.View>
			<GridView ColumnHeaderContainerStyle="{StaticResource ColumnHeaderStyle}">
				
				<GridViewColumn Header="ID"  Width="auto" DisplayMemberBinding="{Binding ID}" />
				<GridViewColumn Header="PrimaryFile"   Width="auto"  >
					<GridViewColumn.CellTemplate>
						<DataTemplate>
							<TextBlock Text="{Binding PrimaryFile}">
								<TextBlock.InputBindings>
									<MouseBinding Gesture="LeftDoubleClick" Command="{Binding Path=DataContext.ShowFileCommand, RelativeSource={RelativeSource AncestorType={x:Type UserControl}}}" CommandParameter="{Binding PrimaryFile}"/>
								</TextBlock.InputBindings>
							</TextBlock>
						</DataTemplate>
					</GridViewColumn.CellTemplate>
				</GridViewColumn>
			</GridView>
		</ListView.View>
		
	</ListView>
