    <WrapPanel x:Name="itmTempPanel" IsItemsHost="True" ItemWidth="60" ItemHeight="60" 
               Width="{Binding ElementName=lstFilesDropped, Path=Width}">
      <WrapPanel.Style>
         <Style TargetType="WrapPanel">
            <Style.Triggers>
               <DataTrigger Binding="{Binding IsMouseOver,ElementName=image}" 
                            Value="True">
                   <DataTrigger.EnterActions>
                     <BeginStoryboard>
                       <Storyboard>
                         <DoubleAnimation Storyboard.TargetProperty="Height" 
                                          To="71"  Duration="0:0:0.3" />
                       </Storyboard>
                     </BeginStoryboard>
                   </DataTrigger.EnterActions>
               </DataTrigger>
            </Style.Triggers>
         </Style>
      </WrapPanel.Style>
    </WrapPanel>
    <Image Name="image">
      <Image.Triggers>
        <EventTrigger RoutedEvent="MouseEnter">
          <BeginStoryboard>
            <Storyboard>
               <DoubleAnimation Storyboard.TargetProperty="Height" To="71"
                                Duration="0:0:0.3" />     
            </Storyboard>
          </BeginStoryboard>
        </EventTrigger>
      </Image.Triggers>
    </Image>
