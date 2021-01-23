    <Button Name="doneButton" Content="Done" IsDefault="True">
      <Button.Style>
        <Style TargetType="{x:Type Button}">
          <Setter Property="IsEnabled" Value="false" />
          <Style.Triggers>
            <MultiDataTrigger>
              <MultiDataTrigger.Conditions>
                <Condition Binding="{Binding ElementName=nameTextBox, Path=(Validation.HasError)}" Value="false" />
              </MultiDataTrigger.Conditions>
              <Setter Property="IsEnabled" Value="true" />
            </MultiDataTrigger>
          </Style.Triggers>
        </Style>
      </Button.Style>
    </Button>
