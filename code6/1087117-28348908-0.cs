    <Rectangle ...>
        <Rectangle.Style>
            <Style TargetType="{x:Type Rectangle}">
                <Setter Property="Fill">
                    <Setter.Value>
                        <ImageBrush ImageSource="{Binding ImageUrl}"/>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter Property="Fill">
                            <Setter.Value>
                                <ImageBrush ImageSource="{Binding HoverImageUrl}"/>
                            </Setter.Value>
                        </Setter>
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Rectangle.Style>
    </Rectangle>
