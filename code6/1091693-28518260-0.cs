    <ListView.ItemContainerStyle>
				<Style TargetType="{x:Type ListViewItem}">
					<Setter Property="Tag" Value="{Binding RelativeSource={RelativeSource AncestorType=ListView}, Path=DataContext}"/>
                    <Setter Property="ContextMenu">
                        <Setter.Value>
                            <ContextMenu DataContext="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                                <MenuItem Header="New" Command="{Binding AddCommand}"/>
                                <MenuItem Header="Clone" Command="{Binding CloneCommand}"/>
                            </ContextMenu>
                        </Setter.Value>
                    </Setter>
				</Style>
			</ListView.ItemContainerStyle>
