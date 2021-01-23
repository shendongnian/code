    <ResourceDictionary>
      <DataTemplate x:Key="PreviewMouseDownCommandTemplate">
        <StackPanel>
          <i:Interaction.Triggers>
            <i:EventTrigger EventName="PreviewMouseDown">
              <command:EventToCommand Command="{Binding MyCommandProvider.PreviewMouseDownCommand,
                                                Mode=OneWay,
                                                Source={StaticResource Locator}}"
                                      CommandParameter="{Binding Mode=OneWay}" />
            </i:EventTrigger>
          </i:Interaction.Triggers>
          <!-- Content -->
        </StackPanel>
      </DataTemplate>
    </ResourceDictionary>
