    <Button>
       <Button.Template>
            <ControlTemplate TargetType="{x:Type Button}">                
                <Grid>
                  <Border x:Name="bdr_main" CornerRadius="5" BorderThickness="2" 
                          BorderBrush="#FFBC89BC" Background="White">  
                    <ContentPresenter VerticalAlignment="Center" HorizontalAlignment="Center" Margin="8,6,8,6" ContentSource="Content" />
                  </Border>
                  <Border Name="b2" Background="#FF603276" Opacity="0" CornerRadius="5" BorderThickness="2" BorderBrush="#FFBC89BC">
                  </Border>
                </Grid>
                <ControlTemplate.Triggers>
                    <Trigger Property="IsMouseOver" Value="True">
                        <Setter TargetName="bdr_main" Property="Background" Value="#FF603276"/>
                    </Trigger>
                    <EventTrigger RoutedEvent="Button.Click">
                       <BeginStoryboard>
                          <Storyboard>
                             <DoubleAnimation Storyboard.TargetName="b2" Storyboard.TargetProperty="Opacity" To="1" Duration="0"/>
                          </Storyboard>
                       </BeginStoryboard>
                    </EventTrigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Button.Template>
    </Button>
