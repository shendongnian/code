     <Grid>
        <ContentControl Content="{Binding CurrentView}" />
        <Popup IsOpen="{Binding IsAudioSettingsOpen}">
           <ContentControl Content="{Binding AudioSettingsViewModel}" />
        </Popup>
     </Grid>
 
