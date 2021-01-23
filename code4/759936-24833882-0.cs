    <ContentControl Content="{Binding Content}">
        <ContentControl.Style>
            <Style TargetType="{x:Type ContentControl}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Choice}" Value="1">
                        <Setter Property="ContentTemplate" Value="{StaticResource TemplateA}" />
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Choice}" Value="2">
                        <Setter Property="ContentTemplate" Value="{StaticResource TemplateB}" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ContentControl.Style>
    </ContentControl>
