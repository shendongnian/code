    <UserControl.Resources>
        <Style TargetType="{x:Type Rectangle}" x:Key="RectangleButton">
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
    </UserControl.Resources>
    ...
    <Rectangle ... Style="{StaticResource RectangleButton}"/>
