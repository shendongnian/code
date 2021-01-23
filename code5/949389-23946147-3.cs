     <Rectangle Width="104.25px" Height="104.25px" MouseEnter="Rectangle_MouseEnter" MouseLeave="Rectangle_MouseLeave" >
    	<Rectangle.Style>
    		<Style TargetType="{x:Type Rectangle}">
    			<Setter Property="Fill" >
    				<Setter.Value>
    						<ImageBrush ImageSource="{Binding Converter={StaticResource ImageBackgroundColor2048Converter}, Mode=OneWay}"/>
    				</Setter.Value>
    			</Setter>
    			<Style.Triggers>
    				<Trigger Property="Rectangle.IsMouseOver" Value="True">
    					<Setter Property="Fill" >
    						<Setter.Value>
                                 <!-- Whatever you want here -->
    							<ImageBrush ImageSource="{Binding MouseOverImageUri}" /> 
    						</Setter.Value>
    					</Setter>
    				</Trigger>
    		</Style>
    	</Rectangle.Style>
    </Rectangle>
