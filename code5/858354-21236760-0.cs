    <Canvas>
       <Line X1="0" Y1="0" X2="300"  Y2="100"  Fill="Black" StrokeThickness="4" Stroke="Black"     OpacityMask="Black"  >
            <Line.RenderTransform>
                <RotateTransform CenterX="150" CenterY="50"/>
            </Line.RenderTransform>
            <Line.Triggers>
                <EventTrigger RoutedEvent="Loaded">
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="(Line.RenderTransform).(RotateTransform.Angle)" 
                                             To="-360" 
                                             Duration="0:0:1" 
                                             RepeatBehavior="Forever"/>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </Line.Triggers>
        </Line>
    </Canvas>
