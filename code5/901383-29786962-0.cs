    <Rectangle Height="58" Width="375">
		<Rectangle.Style>
		    <Style>							
				<Setter Property="Rectangle.Fill">
					<Setter.Value>
						<ImageBrush ImageSource="Image8.png" Viewbox="0,0,1,.5"/>
					</Setter.Value>
				</Setter>
				<Style.Triggers>
					<Trigger Property="Rectangle.IsMouseOver" Value="true">
						<Setter Property="Rectangle.Fill">
							<Setter.Value>							
								<ImageBrush ImageSource="Image8.png" Viewbox="0,.5,1,.5"/>
							</Setter.Value>
						</Setter>
					</Trigger>
				</Style.Triggers>
			</Style>
		</Rectangle.Style>
	</Rectangle>
