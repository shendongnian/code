    <DataGridTextColumn Header="Description">
        <DataGridTextColumn.Binding>
            <Binding Path="[Description]">
                <Binding.ValidationRules>
                    <local:MyValidationRule />
                </Binding.ValidationRules>
            </Binding>
        </DataGridTextColumn.Binding>
    </DataGridTextColumn>
