       <TextBox Name="txtCalls"/>
        <Button Content="Start">
            <Button.Style>
                <Style TargetType="Button">
                    <Setter Property="IsEnabled" Value="True"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=txtCalls, Path=Text.Length}" Value="0">
                            <Setter Property="IsEnabled" Value="False"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
        <Button Content="Abort">
            <Button.Style>
                <Style TargetType="Button">
                    <Setter Property="IsEnabled" Value="False"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=txtCalls,Path=Text.Length}" Value="0">
                            <Setter Property="IsEnabled" Value="True"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
