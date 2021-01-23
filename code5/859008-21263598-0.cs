    <Image Source="Resources/Desert.jpg" x:Key="image1"/>
    <StackPanel>
        <ToggleButton Name="Button" Content="Change Image" Margin="10" />
        <Image Margin="10,0,10,10">
            <Image.Style>
                <Style>
                    <Setter Property="Image.Source" 
    Value="/YourAppName;component/Resources/Desert.jpg" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding IsChecked, ElementName=Button}" 
    Value="True">
                            <Setter Property="Image.Source" 
    Value="/YourAppName;component/Images/Resources/Koala.jpg" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Image.Style>
        </Image>
    </StackPanel>
