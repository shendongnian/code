    <Grid>
        <FrameworkElement.Resources>
            <ResourceDictionary>
                <Style TargetType="{x:Type local:GradientTitle}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type local:GradientTitle}">
                                <TextBlock x:Name="PART_InlinesPresenter" />
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ResourceDictionary>
        </FrameworkElement.Resources>
        <customControls:GradientTitle>
            <Run Text="TEST1" />
            <LineBreak />
            <Run Text="TEST2" />
            <LineBreak />
            <Run Text="{Binding Path=Title, RelativeSource={RelativeSource AncestorType={x:Type Window}}}" />
        </customControls:GradientTitle>
    </Grid>
