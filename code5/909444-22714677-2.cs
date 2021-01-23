    <Style TargetType="{x:Type DataGridCell}">
    	<Setter Property="Template">
    		<Setter.Value>
    			<ControlTemplate TargetType="{x:Type DataGridCell}">
    				<TextBlock Text="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Content.Text}" TextTrimming="CharacterEllipsis">
    					<TextBlock.ToolTip>
    						<ToolTip Visibility="{Binding RelativeSource={RelativeSource Self}, Path=PlacementTarget, Converter={StaticResource TrimToVisConverter}}">
    							<ToolTip.Content>
    								<TextBlock Text="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=Content.Text}"/>
    							</ToolTip.Content>
    						</ToolTip>
    					</TextBlock.ToolTip>
    				 </TextBlock>
    			</ControlTemplate>
    		</Setter.Value>
    	</Setter>
    </Style>
