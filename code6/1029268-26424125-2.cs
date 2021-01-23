    <Grid>
        <TabControl TabStripPlacement="Left">
            <TabControl.Resources>
                <Style TargetType="{x:Type TabItem}">
                    <Setter Property="HeaderTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <ContentPresenter Content="{TemplateBinding Content}">
                                    <ContentPresenter.LayoutTransform>
                                        <RotateTransform Angle="270" />
                                    </ContentPresenter.LayoutTransform>
                                </ContentPresenter>
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Padding" Value="3" />
                </Style>
            </TabControl.Resources>
            <TabItem Header="Class Creator">
                <local:ClassCreator />
            </TabItem>
            <TabItem Header="Text Replacer">
                <local:TextReplacer />
            </TabItem>
        </TabControl>
    </Grid>
