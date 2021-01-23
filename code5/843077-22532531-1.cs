      <ListBox x:Name="TestList3">
          <ListBox.ItemTemplate>
            <DataTemplate>
              <Button HorizontalContentAlignment="Left">
                <TextBlock Text="{Binding}">
                  <TextBlock.Style>
                    <Style TargetType="TextBlock">
                      <Style.Triggers>
                        <DataTrigger
                          Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type ListBox}},Path=IsMouseOver}"
                          Value="True">
                          <DataTrigger.EnterActions>
                            <BeginStoryboard>
                              <Storyboard>
                                <DoubleAnimation Storyboard.TargetProperty="Opacity"
                                                 From="0.0" To="1.0" Duration="0:0:1"
                                                 RepeatBehavior="Forever"
                                                 AutoReverse="True" />
                              </Storyboard>
                            </BeginStoryboard>
                          </DataTrigger.EnterActions>
                          <DataTrigger.ExitActions>
                            <BeginStoryboard>
                              <Storyboard FillBehavior="Stop">
                                <DoubleAnimation
                                  Storyboard.TargetProperty="Opacity"
                                  To="1" Duration="0:0:1" />
                              </Storyboard>
                            </BeginStoryboard>
                          </DataTrigger.ExitActions>
                        </DataTrigger>
                      </Style.Triggers>
                    </Style>
                  </TextBlock.Style>
                </TextBlock>
              </Button>
            </DataTemplate>
          </ListBox.ItemTemplate>
          <system:String>One</system:String>
          <system:String>Two</system:String>
        </ListBox>
