    <Storyboard x:Key="FlipOpen">
        <DoubleAnimation Duration="0:0:0.3"
            Storyboard.TargetProperty="RenderTransform.(ScaleTransform.ScaleX)"
            To="0" />
    </Storyboard>
    <Storyboard x:Key="FlipClose">
        <DoubleAnimation Duration="0:0:0.3"
             Storyboard.TargetProperty="RenderTransform.(ScaleTransform.ScaleX)"
             From="0"
             To="1" />
    </Storyboard>
    <Style x:Key="GridStyle" TargetType="Grid">
        <Setter Property="RenderTransformOrigin" Value="0.5,0.5" />
        <Setter Property="RenderTransform">
            <Setter.Value>
                <ScaleTransform ScaleX="1" ScaleY="1" />
            </Setter.Value>
        </Setter>
    </Style>
    <Style x:Key="FrontGridStyle" TargetType="Grid"
            BasedOn="{StaticResource GridStyle}">
        <Style.Triggers>
            <DataTrigger Binding="{Binding FlipTheCard}" Value="True">
                <DataTrigger.EnterActions>
                    <BeginStoryboard Storyboard="{StaticResource FlipOpen}" />
                </DataTrigger.EnterActions>
                <DataTrigger.ExitActions>
                    <BeginStoryboard Storyboard="{StaticResource FlipClose}" />
                </DataTrigger.ExitActions>
            </DataTrigger>
        </Style.Triggers>
    </Style>
    <Style x:Key="BackGridStyle" TargetType="Grid"
        BasedOn="{StaticResource GridStyle}">
        <Style.Triggers>
            <DataTrigger Binding="{Binding FlipTheCard}" Value="True">
                <DataTrigger.EnterActions>
                    <BeginStoryboard Storyboard="{StaticResource FlipClose}" />
                </DataTrigger.EnterActions>
                <DataTrigger.ExitActions>
                    <BeginStoryboard Storyboard="{StaticResource FlipOpen}" />
                </DataTrigger.ExitActions>
            </DataTrigger>
        </Style.Triggers>
    </Style>
