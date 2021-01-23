            <CheckBox>
                <CheckBox.Visibility>
                    <MultiBinding Converter="{StaticResource MyConverter}">
                        <Binding Path="IsEnable"/>
                        <Binding ElementName="Allowed" Path="IsChecked"/>
                    </MultiBinding>
                </CheckBox.Visibility>
            </CheckBox>
