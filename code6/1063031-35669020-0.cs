                <EventTrigger RoutedEvent="ButtonBase.MouseEnter">
                    <BeginStoryboard x:Name="Sb">
                        <Storyboard>
                            <DoubleAnimation 
                                   From="0" 
                                   To="1" 
                                   BeginTime="00:00:5"
                                   Duration="00:00:5"                                   
                                   Storyboard.TargetProperty="Opacity"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
                <EventTrigger RoutedEvent="ButtonBase.MouseLeave">
                    <StopStoryboard BeginStoryboardName="Sb"/>
                </EventTrigger>
