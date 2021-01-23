    <StackPanel>
      <TextBlock x:Name="textBox1" FontSize="36" Text="Hello world!">
        <TextBlock.Triggers>
          <EventTrigger RoutedEvent="TextBlock.MouseDown">
            <BeginStoryboard>
              <Storyboard>
                <DoubleAnimation Storyboard.TargetName="textBox1"
                                 Storyboard.TargetProperty="Opacity"
                                 From="{Binding ElementName=textBox1, Path=Opacity}"
                                 Duration="0:0:2"
                                 AutoReverse="False">
                  <DoubleAnimation.To>
                    <Binding ElementName="textBox1" Path="Opacity">
                      <Binding.Converter>
                        <local:SubtractFromConverter />
                      </Binding.Converter>
                      <Binding.ConverterParameter>
                        <system:Double>1.0</system:Double>
                      </Binding.ConverterParameter>
                    </Binding>
                  </DoubleAnimation.To>
                </DoubleAnimation>
              </Storyboard>
            </BeginStoryboard>
          </EventTrigger>
        </TextBlock.Triggers>
      </TextBlock>
      <StackPanel Orientation="Horizontal">
        <TextBlock Text="Opacity: " />
        <TextBlock Text="{Binding ElementName=textBox1, Path=Opacity}" />
      </StackPanel>
      <StackPanel Orientation="Horizontal">
        <TextBlock Text="Opacity: " />
        <TextBlock>
          <TextBlock.Text>
            <Binding ElementName="textBox1" Path="Opacity">
              <Binding.Converter>
                <local:SubtractFromConverter />
              </Binding.Converter>
              <Binding.ConverterParameter>
                <system:Double>1.0</system:Double>
              </Binding.ConverterParameter>
            </Binding>
          </TextBlock.Text>
        </TextBlock>
      </StackPanel>
    </StackPanel>
