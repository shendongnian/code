    <UserControl.Resources>
            <Style TargetType="sdk:DataGridColumnHeader">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="sdk:DataGridColumnHeader">
                            <Canvas x:Name="RootElement" Height="60" HorizontalAlignment="Stretch">
                                <ContentPresenter Canvas.Left="15" Canvas.Top="50" Content="{TemplateBinding Content}">
                                    <ContentPresenter.RenderTransform>
                                        <RotateTransform Angle="-90"/>
                                    </ContentPresenter.RenderTransform>
                                </ContentPresenter>
                            </Canvas>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </UserControl.Resources>
