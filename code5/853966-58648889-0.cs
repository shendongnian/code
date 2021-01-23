              The XAML:
              <StackPanel Grid.Row="1"
                          Grid.ColumnSpan="2"
                          Orientation="Horizontal"
                          >
                <atris:AtrLabel Width="15"
                                HorizontalAlignment="Left"
                                Content="1"
                                Style="{StaticResource SomeStyle}"
                                />
                <atris:AtrButton Margin="0,0,0,0"
                                 HorizontalAlignment="Left"
                                 VerticalAlignment="Stretch"
                                 VerticalContentAlignment="Top"
                                 Command="{Binding SomeCommand}"
                                 Content="Deposit"
                                 >
                  <i:Interaction.Triggers>
                    <i:EventTrigger EventName="GotFocus">
                      <cmd:EventToCommand Command="{Binding Path=SetLabelForeground}" PassEventArgsToCommand="True"/>
                    </i:EventTrigger>
                    <i:EventTrigger EventName="LostFocus">
                      <cmd:EventToCommand Command="{Binding Path=RemoveLabelForeground}" PassEventArgsToCommand="True"/>
                    </i:EventTrigger>
                  </i:Interaction.Triggers>
                </atris:AtrButton>
                </StackPanel>
              The ViewModel:
                 protected sealed override void InitCommands()
                {
                   SetLabelForeground = new RelayCommand<RoutedEventArgs>(SetForegroundOnLable);
                   RemoveLabelForeground = new RelayCommand<RoutedEventArgs>(UnSetForegroundOnLable);
                }
                   //changes the number back to gray and removes underline 
                  private void UnSetForegroundOnLable(RoutedEventArgs obj)
                  {
                    Label closestLable = GetChildLabel(obj);
                    closestLable.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#666666"));
                    TextBlock childTextBlock = UIHelper.FindVisualChild<TextBlock>(closestLable);
                    childTextBlock.TextDecorations.Remove(TextDecorations.Underline[0]);
                  }
                  //changes the number to blue and underlines it
                  private void SetForegroundOnLable(RoutedEventArgs obj)
                  {
                    Label closestLable = GetChildLabel(obj);
                    closestLable.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF009df3"));
                    TextBlock childTextBlock = UIHelper.FindVisualChild<TextBlock>(closestLable);
                    childTextBlock.TextDecorations.Add(System.Windows.TextDecorations.Underline);
                  }
                  //gets the number next to the button
                  private static Label GetChildLabel(RoutedEventArgs obj)
                  {
                    Button buttonThatHasFocus = (Button)obj.OriginalSource;
                    DependencyObject parent = VisualTreeHelper.GetParent(buttonThatHasFocus);
                    Label closestLable = UIHelper.FindVisualChild<Label>(parent);
                    return closestLable;
                  }
