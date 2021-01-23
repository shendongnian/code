    <DataTemplate x:Key="ProjectTemplate">
    <StackPanel Orientation="Horizontal">
       <ProgressBar Value="{Binding BuildProgress}" />
       <TextBox Text="{Binding Label}" IsEnabled="{Binding IsLabelAvailable}" />
       <CheckBox Content="Archive" IsChecked="{Binding ToBeArchived}" IsEnabled="{Binding IsAvailable}" />
       <Button Content="Build" 
               Command="{Binding Path=BuildCommand}" 
               IsEnabled="{Binding CanBuild}"  />
       <Button Content="Rebuild" 
               Command="{Binding Path=RebuildCommand}" 
               IsEnabled="{Binding CanReBuild}" />
       <Button Content="Publish" 
               Command="{Binding Path=PublishCommand}" 
               IsEnabled="{Binding CanPublish}" />
       <TextBlock Text="{Binding Status}" />
       </StackPanel>
    </DataTemplate>
