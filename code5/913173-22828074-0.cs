    <ListBox>
          <ListBox.Resources>
            <Style TargetType="{x:Type ListBoxItem}">
              <Setter Property="HorizontalContentAlignment"
                      Value="Stretch" />
              <Style.Triggers>
                <Trigger Property="IsMouseOver"
                         Value="True">
                  <Setter Property="Control.Background"
                          Value="Orange" />
                  <Setter Property="Control.BorderBrush"
                          Value="SteelBlue" />
                  <Setter Property="Control.BorderThickness"
                          Value="1" />
                  <Trigger.EnterActions>
                    <BeginStoryboard>
                      <Storyboard>
                        <DoubleAnimation Storyboard.TargetProperty="Opacity"
                                         To=".5"
                                         Duration="0:0:0.4" />
                      </Storyboard>
                    </BeginStoryboard>
                  </Trigger.EnterActions>
                  <Trigger.ExitActions>
                    <BeginStoryboard>
                      <Storyboard>
                        <DoubleAnimation Storyboard.TargetProperty="Opacity"
                                         To="0"
                                         Duration="0:0:0" />
                      </Storyboard>
                    </BeginStoryboard>
                  </Trigger.ExitActions>
                </Trigger>
              </Style.Triggers>
    
            </Style>
          </ListBox.Resources>
    
        <ListBoxItem>AAA</ListBoxItem>
          <ListBoxItem>BBB</ListBoxItem>
          <ListBoxItem>CCC</ListBoxItem>
    
        </ListBox>
