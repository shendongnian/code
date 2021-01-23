    Window x:Class="WpfApplication8.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"             
        xmlns:chartingToolkit="clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit"
        xmlns:visualizationToolkit="clr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit"
        xmlns:datavis ="clr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit"
        Title="Window1" Height="500" Width="700">
    <Window.Resources>
        <Style x:Key="LineSeriesStyle1" TargetType="{x:Type chartingToolkit:LineSeries}">
            <Setter Property="IsTabStop" Value="False"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type chartingToolkit:LineSeries}">
                        <Canvas x:Name="PlotArea">
                            <Polyline Points="{TemplateBinding Points}" Stroke="{Binding Tag,RelativeSource={RelativeSource AncestorType={x:Type chartingToolkit:LineSeries}}}" />
                        </Canvas>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    <Grid>
        <chartingToolkit:Chart x:Name="mcChart"  >
            <chartingToolkit:LineSeries Tag="Green" x:Name="chart" DependentValuePath="Value"  IsSelectionEnabled="True" IndependentValuePath="Key" ItemsSource="{Binding}" Style="{StaticResource LineSeriesStyle1}">
                <chartingToolkit:LineSeries.LegendItemStyle>
                    <Style TargetType="chartingToolkit:LegendItem" >
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type chartingToolkit:LegendItem}">
                                    <Border BorderBrush="Black" BorderThickness="0">
                                        <StackPanel>
                                            <StackPanel Orientation="Horizontal" >
                                                <Rectangle Width="12" Height="12" Fill="{Binding ElementName=chart,Path=Tag}" StrokeThickness="1"  />
                                                <datavis:Title Content="{TemplateBinding Content}" Foreground="{Binding ElementName=chart,Path=Tag}" FontSize="18" Margin="10"/>
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
