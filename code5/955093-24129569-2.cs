     <Button>
            <Button.Style>
                <Style TargetType="Button">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=start, Path=IsPressed}" Value="True">
                            <DataTrigger.EnterActions>
                                <BeginStoryboard>
                                    ...
                                </BeginStoryboard>
                            </DataTrigger.EnterActions>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
