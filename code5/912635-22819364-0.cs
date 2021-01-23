    <DataTrigger Binding="{Binding IsShowing}" Value="True">
        <DataTrigger.EnterActions>
            <BeginStoryboard>
                <Storyboard>
                    <DoubleAnimation From="0.5" To="1" Duration="0:0:0.2" 
                            Storyboard.TargetProperty="RenderTransform.ScaleX" />
                    <DoubleAnimation From="0.5" To="1" Duration="0:0:0.2" 
                            Storyboard.TargetProperty="RenderTransform.ScaleY" />
                </Storyboard>
            </BeginStoryboard>
        </DataTrigger.EnterActions>
        <DataTrigger.ExitActions>
            <BeginStoryboard>
                <Storyboard>
                    <DoubleAnimation To="0.5" Duration="0:0:0.1" 
                             Storyboard.TargetProperty="RenderTransform.ScaleX"/>
                    <DoubleAnimation To="0.5" Duration="0:0:0.1" 
                             Storyboard.TargetProperty="RenderTransform.ScaleY"/>
                </Storyboard>
            </BeginStoryboard>
        </DataTrigger.ExitActions>
    </DataTrigger>
