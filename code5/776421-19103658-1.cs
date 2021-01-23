        <TextBlock Text="Department Code" Grid.Row="0"/>
        <TextBox Name="DepartmentCodeTextBox"  Grid.Row="0" Margin="150,0,0,0">
            <TextBox.Text>
                <Binding Path="Department.DepartmentCode" Mode="TwoWay" UpdateSourceTrigger="PropertyChanged">
                    <Binding.ValidationRules>
                        <local:DepartmentValidationRule/>
                    </Binding.ValidationRules>
                </Binding>
            </TextBox.Text>
        </TextBox>
        <TextBlock Text="Department Name" Grid.Row="1"/>
        <TextBox Name="DepartmentNameTextBox" Grid.Row="1" ToolTip="Hi" Margin="150,0,0,0">
            <TextBox.Text>
                <Binding Path="Department.DepartmentFullName" Mode="TwoWay" UpdateSourceTrigger="PropertyChanged">
                    <Binding.ValidationRules>
                        <local:DepartmentValidationRule/>
                    </Binding.ValidationRules>
                </Binding>
            </TextBox.Text>
        </TextBox>
