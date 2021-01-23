    <Application.Resources>
        <ResourceDictionary>
            <!-- declaring the style and template without a key enables them to be consumed as the default style --> 
            <Style TargetType="{x:Type local:ImageDialogue}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type local:ImageDialogue}">
                            <Grid Background="DarkGray"
                                  Height="{TemplateBinding Height}"
                                  Width="{TemplateBinding Width}">
                                <Image Source="{TemplateBinding ImageSource}" />
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ResourceDictionary>
    </Application.Resources>
