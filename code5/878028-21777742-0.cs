    <ResourceDictionary ...>
       <ResourceDictionary.MergedDictionaries>
          <ResourceDictionary Source="/assembly;component/myDic.xaml" />
       </ResourceDictionary.MergedDictionaries>
             <Style TargetType="{x:Type localui:MyControl}">
                  <Setter Property="Template">
                      <Setter.Value>
                          <ControlTemplate TargetType="{x:Type localui:MyControl}">
                                <Button Style="{StaticResource narrowButton}">...</Button>
                          </ControlTemplate>
                      </Setter.Value>
                 </Setter>
              </Style>
    </ResourceDictionary>
