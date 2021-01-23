      <Button Click="Button_Click">
            <Image Width="154" Height="87" >
                <Image.Style>
                    <Style TargetType="Image">
                        <Style.Triggers>
                            <Trigger Property="IsEnabled" Value="False">
                                <Setter Property="Source">
                                    <Setter.Value>
                                        <FormatConvertedBitmap DestinationFormat="Gray32Float">
                                            <FormatConvertedBitmap.Source>
                                                <BitmapImage UriSource="1.png" />
                                            </FormatConvertedBitmap.Source>
                                        </FormatConvertedBitmap>
                                    </Setter.Value>
                                </Setter>
                            </Trigger>
                            <Trigger Property="IsEnabled" Value="True">
                                <Setter Property="Source">
                                    <Setter.Value>                                        
                                                <BitmapImage UriSource="1.png" />                                          
                                    </Setter.Value>
                                </Setter>
                            </Trigger>                     
                        </Style.Triggers>                                          
                    </Style>
                </Image.Style>
            </Image>
        </Button>
