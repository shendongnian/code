    <Button Width="100" Height="100" Content="CONTENT">
        <Button.Template>
            <ControlTemplate TargetType="Button">
                <Grid Background="{TemplateBinding Background}">
                    <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                </Grid>
                <ControlTemplate.Triggers>
                    <DataTrigger Value="True">
                        <DataTrigger.Binding>
                            <MultiBinding>
                                <MultiBinding.Converter>
                                    <WpfApplication2:TestConverter />
                                </MultiBinding.Converter>
                                <Binding RelativeSource="{RelativeSource Self}" Path="IsMouseOver"></Binding>
                                <Binding RelativeSource="{RelativeSource Self}" Path="IsKeyboardFocusWithin"></Binding>
                            </MultiBinding>
                        </DataTrigger.Binding>
                        <Setter Property="Foreground" Value="White" />                        
                    </DataTrigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Button.Template>
    </Button>
