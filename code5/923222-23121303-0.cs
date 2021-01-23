    <ListView>
    	<ListView.Resources>
    		<Style TargetType="{x:Type ListViewItem}">
    			<Setter Property="Template">
    				<Setter.Value>
    					<ControlTemplate TargetType="{x:Type ListBoxItem}">
    						<Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="True">
    							<ContentPresenter ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" ContentStringFormat="{TemplateBinding ContentStringFormat}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
    						</Border>
    						<ControlTemplate.Triggers>
    							<MultiTrigger>
    								<MultiTrigger.Conditions>
    									<Condition Property="IsMouseOver" Value="True"/>
    								</MultiTrigger.Conditions>
    								<MultiTrigger.EnterActions>
    									<BeginStoryboard>
    										<Storyboard>
    											<ColorAnimation Storyboard.TargetName="Bd" Storyboard.TargetProperty="Background.Color" To="{x:Static SystemColors.HighlightColor}" Duration="00:00:00.5" />
    										</Storyboard>
    									</BeginStoryboard>
    								</MultiTrigger.EnterActions>
    								<MultiTrigger.ExitActions>
    									<BeginStoryboard>
    										<Storyboard>
    											<ColorAnimation Storyboard.TargetName="Bd" Storyboard.TargetProperty="Background.Color" To="Transparent" Duration="00:00:02" />
    										</Storyboard>
    									</BeginStoryboard>
    								</MultiTrigger.ExitActions>
    								<Setter Property="Background" TargetName="Bd" Value="Transparent"/>
    								<Setter Property="BorderBrush" TargetName="Bd" Value="Transparent"/>
    							</MultiTrigger>
    							<MultiTrigger>
    								<MultiTrigger.Conditions>
    									<Condition Property="Selector.IsSelectionActive" Value="False"/>
    									<Condition Property="IsSelected" Value="True"/>
    								</MultiTrigger.Conditions>
    								<Setter Property="Background" TargetName="Bd" Value="#3DDADADA"/>
    								<Setter Property="BorderBrush" TargetName="Bd" Value="#FFDADADA"/>
    							</MultiTrigger>
    							<MultiTrigger>
    								<MultiTrigger.Conditions>
    									<Condition Property="Selector.IsSelectionActive" Value="True"/>
    									<Condition Property="IsSelected" Value="True"/>
    								</MultiTrigger.Conditions>
    								<Setter Property="Background" TargetName="Bd" Value="#3D26A0DA"/>
    								<Setter Property="BorderBrush" TargetName="Bd" Value="#FF26A0DA"/>
    							</MultiTrigger>
    							<Trigger Property="IsEnabled" Value="False">
    								<Setter Property="TextElement.Foreground" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
    							</Trigger>
    						</ControlTemplate.Triggers>
    					</ControlTemplate>
    				</Setter.Value>
    			</Setter>
    		</Style>
    	</ListView.Resources>
    	<ListView.Items>
    		<ListViewItem>
    			<TextBlock Text="Item 1" />
    		</ListViewItem>
    		<ListViewItem>
    			<TextBlock Text="Item 2" />
    		</ListViewItem>
    		<ListViewItem>
    			<TextBlock Text="Item 3" />
    		</ListViewItem>
    		<ListViewItem>
    			<TextBlock Text="Item 4" />
    		</ListViewItem>
    		<ListViewItem>
    			<TextBlock Text="Item 5" />
    		</ListViewItem>
    	</ListView.Items>
    </ListView>
