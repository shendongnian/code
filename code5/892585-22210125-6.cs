    <Rectangle Canvas.Top="30" Canvas.Left="10" Name="coloredRectangle" ... >
        <Rectangle.Style>
            <Style>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding SomeBooleanProperty}" Value="True">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard>
                                <Storyboard ... />
                            </BeginStoryboard>
                        </DataTrigger.EnterActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Rectangle.Style>
    </Rectangle>
