     <Style TargetType="{x:Type usrctrl:ProgressWaitSpinner}">
        <Style.Triggers>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding ElementName=label1, Path=Content}" Value="NotStarted"></Condition>
                </MultiDataTrigger.Conditions>
                <Setter Property="Background" Value="Red" />
                <Setter Property="IsSpinning" Value="false"/>
            </MultiDataTrigger>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding ElementName=label1, Path=Content}" Value="Running"></Condition>
                </MultiDataTrigger.Conditions>
                <Setter Property="Background" Value="Chocolate" />
                <Setter Property="IsSpinning" Value="true" />
            </MultiDataTrigger>
        </Style.Triggers>
    </Style>
