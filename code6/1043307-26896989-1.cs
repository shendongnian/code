    public class ElementsConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var elements = values[0] as IEnumerable<ElementViewModel>;
            var depth = (int)values[1];
    
            if (depth <= 9) // depthLimit can be passed through parameter (MultiBinding.ConverterParameter property) or via AmbientContext. Actually many ways exist.
            {
                return elements;
            }
            else
            {
                return new ElementViewModel[0];
            }
        }
    
        public object[] ConverBack(bject value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    <ItemsControl>
        <ItemsControl.ItemsSource>
            <MultiBinding Mode="OneWay">
                <MultiBinding.Converter>
                     <localNamespace:ElementsConverter/>
                </MultiBinding.Converter>   
                <Binding Path="Elements"/>
                <Binding Path="Depth"/>
           </MultiBinding>
        </ItemsControl.ItemsSource>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="ContentPresenter">
                <Setter Property="Canvas.Left" Value="{Binding Left}"/>
                <Setter Property="Canvas.Top" Value="{Binding Top}"/>
                <Setter Property="Width" Value="{Binding Width}"/>
                <Setter Property="Height" Value="{Binding Height}"/>
            </Style>
        </ItemsControl.ItemContainerStyle>
    </ItemsControl>
