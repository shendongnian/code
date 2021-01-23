            <chartingToolkit:ColumnSeries ItemsSource="{Binding}" DependentValuePath="AantalMeldingen" IndependentValuePath="Afdeling" Margin="0,0,0,1"  Title="Aantal meldingen" Padding="0" VerticalContentAlignment="Center" HorizontalContentAlignment="Center" FontSize="8">
                <chartingToolkit:ColumnSeries.IndependentAxis>
                    <chartingToolkit:CategoryAxis Orientation="X">
                        <chartingToolkit:CategoryAxis.AxisLabelStyle>
                            <Style TargetType="chartingToolkit:AxisLabel">
                                <Setter Property="Template">
                                    <Setter.Value>
                                        <ControlTemplate TargetType="chartingToolkit:AxisLabel">
                                            <TextBlock Text="{TemplateBinding FormattedContent}">
                                                    <TextBlock.LayoutTransform>
                                                        <RotateTransform Angle="-90"/>
                                                    </TextBlock.LayoutTransform>
                                            </TextBlock>
                                        </ControlTemplate>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </chartingToolkit:CategoryAxis.AxisLabelStyle>
                    </chartingToolkit:CategoryAxis>
                </chartingToolkit:ColumnSeries.IndependentAxis>
            </chartingToolkit:ColumnSeries>
