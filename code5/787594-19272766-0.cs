    <Style x:Key="HeaderedContentControlStyle" TargetType="HeaderedContentControl">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="HeaderedContentControl">
                    <Grid Style="{StaticResource MenuItemGridStyle}">
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="30" />
                        </Grid.ColumnDefinitions>
                        <TextBlock Grid.Column="0" Style="{StaticResource MenuItemTextblockStyle}" Text="{TemplateBinding Header}" />
                        <Image Grid.Column="1" Source="{TemplateBinding Content}" />
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
