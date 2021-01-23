     <Window.Resources>
        <Style x:Key="LineSeriesStyle1" TargetType="{x:Type chartingToolkit:LineSeries}">
            <Setter Property="Tag" Value="{Binding Tag,RelativeSource={RelativeSource AncestorType={x:Type chartingToolkit:LineSeries}}}"></Setter>
            <Setter Property="OverridesDefaultStyle" Value="True"></Setter>
            <Setter Property="IsTabStop" Value="False"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type chartingToolkit:LineSeries}">
                        <Canvas x:Name="PlotArea">
                            <Polyline x:Name="polyline"  Points="{TemplateBinding Points}" Stroke="{Binding Tag,RelativeSource={RelativeSource TemplatedParent}}" />
                        </Canvas>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    <Grid>
        <chartingToolkit:Chart Name="lineChart">
            <chartingToolkit:LineSeries Name="chart1" Tag="Blue" Background="Green"  Style="{StaticResource LineSeriesStyle1}" Title="KW Gastats"  DependentValuePath="Value" IndependentValuePath="Key" ItemsSource="{Binding [0]}" IsSelectionEnabled="True">
                <chartingToolkit:LineSeries.LegendItemStyle>
                    <Style TargetType="{x:Type chartingToolkit:LegendItem}" >
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type chartingToolkit:LegendItem}">
                                    <Border >
                                        <StackPanel>
                                            <StackPanel Orientation="Horizontal" >
                                                <Rectangle Width="12" Height="12" Fill="{Binding ElementName=chart1,Path=Tag}"  Stroke="{Binding Background}" StrokeThickness="1"  />
                                                <datavis:Title Content="{TemplateBinding Content}" Foreground="{Binding ElementName=chart1,Path=Tag}" FontSize="18" Margin="10"/>
                                            </StackPanel>
                                        </StackPanel>
                                    </Border>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </chartingToolkit:LineSeries.LegendItemStyle>
            </chartingToolkit:LineSeries>
            <chartingToolkit:LineSeries Name="chart2" Tag="Green"   Style="{StaticResource LineSeriesStyle1}" Title="Preu KW"   DependentValuePath="Value" IndependentValuePath="Key" ItemsSource="{Binding [1]}" IsSelectionEnabled="True" >
                <chartingToolkit:LineSeries.LegendItemStyle>
                    <Style TargetType="{x:Type chartingToolkit:LegendItem}" >
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type chartingToolkit:LegendItem}">
                                    <Border >
                                        <StackPanel>
                                            <StackPanel Orientation="Horizontal" >
                                                <Rectangle Width="12" Height="12" Fill="{Binding ElementName=chart2,Path=Tag}"   StrokeThickness="1"  />
                                                <datavis:Title Content="{TemplateBinding Content}" Foreground="{Binding ElementName=chart2,Path=Tag}" FontSize="18" Margin="10"/>
                                            </StackPanel>
                                        </StackPanel>
                                    </Border>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </chartingToolkit:LineSeries.LegendItemStyle>
            </chartingToolkit:LineSeries>
        </chartingToolkit:Chart>
    </Grid>
