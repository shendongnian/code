    <charting:PieSeries.DataPointStyle>
        <Style TargetType="charting:PieDataPoint">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="charting:PieDataPoint">
                        <Grid x:Name="Root" Opacity="0">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualStateGroup.Transitions>
                                        <VisualTransition GeneratedDuration="0:0:0.1" />
                                    </VisualStateGroup.Transitions>
                                    <VisualState x:Name="Normal" />
                                    <VisualState x:Name="MouseOver">
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="MouseOverHighlight" Storyboard.TargetProperty="Opacity" To="0.6" Duration="0" />
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="SelectionStates">
                                    <VisualStateGroup.Transitions>
                                        <VisualTransition GeneratedDuration="0:0:0.1" />
                                    </VisualStateGroup.Transitions>
                                    <VisualState x:Name="Unselected" />
                                    <VisualState x:Name="Selected">
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="SelectionHighlight" Storyboard.TargetProperty="Opacity" To="0.6" Duration="0" />
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="RevealStates">
                                    <VisualStateGroup.Transitions>
                                        <VisualTransition GeneratedDuration="0:0:0.5" />
                                    </VisualStateGroup.Transitions>
                                    <VisualState x:Name="Shown">
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="Root" Storyboard.TargetProperty="Opacity" To="1" Duration="0" />
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Hidden">
                                        <Storyboard>
                                            <DoubleAnimation Storyboard.TargetName="Root" Storyboard.TargetProperty="Opacity" To="0" Duration="0" />
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <Path x:Name="Slice" Data="{TemplateBinding Geometry}" Fill="{Binding Color}" Stroke="{TemplateBinding BorderBrush}" StrokeMiterLimit="1">
                                <ToolTipService.ToolTip>
                                    <StackPanel>
                                        <ContentControl Content="{TemplateBinding FormattedDependentValue}" />
                                        <ContentControl Content="{TemplateBinding FormattedRatio}" />
                                    </StackPanel>
                                </ToolTipService.ToolTip>
                            </Path>
                            <Path x:Name="SelectionHighlight" Data="{TemplateBinding GeometrySelection}" Fill="Red" StrokeMiterLimit="1" IsHitTestVisible="False" Opacity="0" />
                            <Path x:Name="MouseOverHighlight" Data="{TemplateBinding GeometryHighlight}" Fill="White" StrokeMiterLimit="1" IsHitTestVisible="False" Opacity="0" />
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </charting:PieSeries.DataPointStyle>
