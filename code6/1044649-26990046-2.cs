    <Application.Resources>
      <Style TargetType="{x:Type customControls:MyCustomButton}">
        <Style.Setters>
          <Setter Property="Template">
            <Setter.Value>
              <ControlTemplate TargetType="{x:Type customControls:MyCustomButton}">
                <ContentPresenter Content="{Binding Path=MyClassA, 
                                  RelativeSource={RelativeSource TemplatedParent}}" />
              </ControlTemplate>
            </Setter.Value>
          </Setter>
        </Style.Setters>
      </Style>
    </Application.Resources>
