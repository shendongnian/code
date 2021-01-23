    <Style.Triggers>
      <Trigger Property="IsEnabled" Value="false">
        <Setter Property="Background" Value="#EEEEEE" />
      </Trigger>
    
      <MultiTrigger>
        <MultiTrigger.Conditions>
          <Condition Property="HasItems" Value="false" />
          <Condition Property="Width" Value="Auto" />
        </MultiTrigger.Conditions>
        <Setter Property="MinWidth" Value="120"/>
      </MultiTrigger>
    
      <MultiTrigger>
        <MultiTrigger.Conditions>
          <Condition Property="HasItems" Value="false" />
          <Condition Property="Height" Value="Auto" />
        </MultiTrigger.Conditions>
        <Setter Property="MinHeight" Value="95"/>
      </MultiTrigger>
    </Style.Triggers>
