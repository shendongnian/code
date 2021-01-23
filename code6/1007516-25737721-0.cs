	<ListView Grid.IsSharedSizeScope="True">
 
        <ListView.Resources>
		    <Style TargetType="{x:Type GridViewColumnHeader}">
			   <Setter Property="HorizontalContentAlignment" Value="Left"/>			
		    </Style>
		    <Style TargetType="{x:Type ListViewItem}">
			   <Setter Property="HorizontalAlignment" Value="Stretch"/>	<!-- Redundent -->		
	        </Style>
        </ListView.Resources>
        <ListView.View>
               <GridView>								
                <GridViewColumn Header="Amount" >
				<GridViewColumn.HeaderTemplate>
					<DataTemplate>
						<Grid>
							<Grid.ColumnDefinitions>
								<ColumnDefinition SharedSizeGroup="A" />
							</Grid.ColumnDefinitions>
							<TextBlock Foreground="Black" Background="AliceBlue" Text="{Binding}"/>
						</Grid>			
					</DataTemplate>
				</GridViewColumn.HeaderTemplate>
				<GridViewColumn.CellTemplate>
                    <DataTemplate>
						<Grid>
							<Grid.ColumnDefinitions>
								<ColumnDefinition SharedSizeGroup="A" />
							</Grid.ColumnDefinitions>
							
							<TextBlock Foreground="Black" Background="AliceBlue" HorizontalAlignment="Right" Text="{Binding Path=Amount}"/>
						</Grid>
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
        
