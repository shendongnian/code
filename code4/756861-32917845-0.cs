    public class ServiceExtension : MarkupExtension
    {
        public ServiceExtension()
        {
        }
        public ServiceExtension(Type serviceType)
        {
            ServiceType = serviceType;
        }
        [ConstructorArgument("serviceType")]
        public Type ServiceType { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Service { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ServiceType == null)
            {
                Service= "ServiceType == null";
                return this;
            }
            var service = serviceProvider.GetService(ServiceType);
            Service= service ?? "null";
            return this;
        }
    }
<!>
    <Style TargetType="{x:Type HeaderedContentControl}">
        <Setter Property="Header" Value="{Binding ServiceType}" />
        <Setter Property="Content" Value="{Binding Service}" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type HeaderedContentControl}">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" SharedSizeGroup="Col1" />
                            <ColumnDefinition />
                        </Grid.ColumnDefinitions>
                        <ContentPresenter Grid.Column="0"
                                          Margin="0,0,5,0"
                                          ContentSource="Header" />
                        <ContentPresenter Grid.Column="1" ContentSource="Content" />
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
