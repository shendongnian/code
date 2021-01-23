    <Style TargetType="local:MyItemsControl"
           BasedOn="{StaticResource {x:Type ItemsControl}}">
        <Setter Property="ItemContainerStyle">
            <Setter.Value>
                <Style TargetType="ContentControl">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ContentControl">
                                <Grid>
                                    <Grid.ColumnDefinitions>
                                        <ColumnDefinition Width="10"/>
                                        <ColumnDefinition Width="*"/>
                                    </Grid.ColumnDefinitions>
                                    <Path Grid.Column="0" ... />
                                    <ContentPresenter Grid.Column="1"
                                        Content="{TemplateBinding Content}"
                                        ContentTemplate="{TemplateBinding ContentTemplate}"/>
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </Setter.Value>
        </Setter>
    </Style>
