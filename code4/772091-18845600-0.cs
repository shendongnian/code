    <ToggleButton>
          <ToggleButton.Style>
                <Style  TargetType="ToggleButton">
                    <Setter Property="Background">
                        <Setter.Value>
                            <ImageBrush ImageSource="/WpfApp;component/Images/image2.png" Stretch="Uniform" TileMode="None" />
                        </Setter.Value>
                    </Setter>
                    <Style.Triggers>
                        <Trigger Property="IsChecked" Value="True">
                            <Setter Property="Background">
                                <Setter.Value>
                                    <ImageBrush ImageSource="/WpfApp;component/Images/image1.png" Stretch="Uniform" TileMode="None" />
                                </Setter.Value>
                            </Setter>
                        </Trigger>
                    </Style.Triggers>
                </Style>
            </ToggleButton.Style>
    </ToggleButton>
