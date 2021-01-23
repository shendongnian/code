    <Style>
        <Style.Triggers>
            <DataTrigger Binding="{Binding IsAnimationRunning}" Value="True">
                <DataTrigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <SomeAnimation />
                        </Storyboard>
                    </BeginStoryboard>
                </DataTrigger.EnterActions>
            </DataTrigger>
        </Style.Triggers>
    </Style>
