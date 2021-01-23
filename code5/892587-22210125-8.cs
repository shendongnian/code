    <Style>
        <Style.Triggers>
            <DataTrigger Binding="{Binding SomeBooleanPropertyInViewModel}" Value="True">
                <DataTrigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard ... />
                    </BeginStoryboard>
                </DataTrigger.EnterActions>
            </DataTrigger>
        </Style.Triggers>
    </Style>
