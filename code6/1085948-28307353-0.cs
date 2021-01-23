    <Button Name="BtnReload" Content="Reload" Command="{Binding DateCommand}">
        <Button.Style>
            <Style TargetType="Button">
               <Setter Property="IsEnabled" Value="{Binding IsEnabled}"/>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding ElementName=BtnValidate,Path=IsEnabled}" Value="False">
                        <Setter Property="IsEnabled" Value="False"/?
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Button.Style>
    </Button>
