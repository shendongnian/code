    <Button Name="Home" HorizontalAlignment="Left" Width="75" Background="#FF252525" BorderThickness="5">
        <Button.Content>
            <Grid HorizontalAlignment="Center" VerticalAlignment="Bottom">
                <TextBlock  FontFamily="/VideoManager;component/#Myriad Pro" FontSize="13.333" Text="Home"></TextBlock>
            </Grid>
        </Button.Content>
        <Button.Template>
            <ControlTemplate TargetType="{x:Type Button}">
                <Border Background="{TemplateBinding Background}">
                    <ContentPresenter />
                </Border>
                <ControlTemplate.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter Property="Foreground" Value="Yellow" />
                        <Setter Property="Background" Value="Red" />
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Button.Template>
    </Button>
