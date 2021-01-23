    <Style TargetType="local:MouseOverImage">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="local:MouseOverImage">
                    <Grid>
                        <Image Name="SourceImage" Source="{TemplateBinding Source}" />
                        <Image Name="Source2Image" Source="{TemplateBinding Source2}" Visibility="Hidden" />
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter TargetName="SourceImage" Property="Visibility" Value="Hidden" />
                            <Setter TargetName="Source2Image" Property="Visibility" Value="Visible" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
