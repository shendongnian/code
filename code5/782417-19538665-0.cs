     <i:Interaction.Behaviors>
            <cimbalinoBehaviors:MultiApplicationBarBehavior 
				SelectedIndex="{Binding SelectedIndex, ElementName=MainInfo, Converter={StaticResource HomeMenuConverter}}" >
                <cimbalinoBehaviors:ApplicationBar Opacity="0.5"  
                                                   IsMenuEnabled="{Binding IsLoading, Converter={StaticResource NegativeBooleanConverter}}">
                    <cimbalinoBehaviors:ApplicationBarIconButton 
						IsVisible="{Binding IsAuthenticated}"
						IsEnabled="{Binding IsLoading, Converter={StaticResource NegativeBooleanConverter}}"
						Command="{Binding GetFavorites, Mode=OneTime}" 
						IconUri="/Assets/appbar.sync.rest.png" Text="{Binding Labels.Translation.Refresh, Source={StaticResource LabelsManager}}" />
                    <cimbalinoBehaviors:ApplicationBarIconButton 
						IsVisible="{Binding SelectionMode, Converter={StaticResource NegativeBooleanConverter}}"
						IsEnabled="{Binding IsLoading, Converter={StaticResource NegativeBooleanConverter}}"
						Command="{Binding SetSelectionMode, Mode=OneTime}" 
						IconUri="/Assets/ApplicationBar.Select.png" Text="{Binding Labels.Translation.Select, Source={StaticResource LabelsManager}}" />
                    <cimbalinoBehaviors:ApplicationBarIconButton 
						IsVisible="{Binding SelectionMode}"
						IsEnabled="{Binding IsLoading, Converter={StaticResource NegativeBooleanConverter}}"
						Command="{Binding DeleteFavorites, Mode=OneTime}" 
						IconUri="/Assets/ApplicationBar.Delete.png" Text="{Binding Labels.Translation.Delete, Source={StaticResource LabelsManager}}" />
                    <cimbalinoBehaviors:ApplicationBarIconButton 
						IsVisible="{Binding SelectionMode}"
						IsEnabled="{Binding IsLoading, Converter={StaticResource NegativeBooleanConverter}}"
						Command="{Binding SetSelectionMode, Mode=OneTime}" 
						IconUri="/Assets/ApplicationBar.Cancel.png" Text="{Binding Labels.Translation.Cancel, Source={StaticResource LabelsManager}}" />
                </cimbalinoBehaviors:ApplicationBar>
            </cimbalinoBehaviors:MultiApplicationBarBehavior>
        </i:Interaction.Behaviors>
