    <ContentControl x:Name="ActionContent" prism:RegionManager.RegionName="{x:Static inf:RegionNames.ActionRegion}">
      <ContentControl.Template>
        <ControlTemplate TargetType="ContentControl">
          <Grid>
            <Controls:RoundedBox />
            <ContentPresenter Margin="10,0,10,0" Content="{TemplateBinding Content}" />
          </Grid>
          <ControlTemplate.Triggers>
            <Trigger Property="HasContent" Value="false">
              <Setter Property="Visibility" Value="Collapsed" />
            </Trigger>
          </ControlTemplate.Triggers>
        </ControlTemplate>
      </ContentControl.Template>
    </ContentControl>
