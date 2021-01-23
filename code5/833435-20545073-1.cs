    <DataTemplate>
        <Grid>
            <Image Source="Resources/Images/Check-icon.png" Visibility="Visible">
                <Image.Style>
                    <Style TargetType="{x:Type Image}">
                        <Setter Visibility="Collapsed" />
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding ElementName=AddressGrid,Path=IsReadOnly}" Value="True">
                                <Setter Property="Visibility" Value="Visible">
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </Image.Style>
            </Image>
            <RadioButton GroupName="grpRadioButtonFacturationAddresses" IsChecked="{Binding Path=IsFacturation, UpdateSourceTrigger=LostFocus, Mode=TwoWay}" VerticalAlignment="Center" HorizontalAlignment="Center">
                <RadioButton.Style>
                    <Style TargetType="{x:Type RadioButton}">
                        <Setter Visibility="Visible" />
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding ElementName=AddressGrid,Path=IsReadOnly}" Value="True">
                                <Setter Property="Visibility" Value="Collapsed">
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </RadioButton.Style>
            </RadioButton>
        </Grid>
    </DataTemplate>
