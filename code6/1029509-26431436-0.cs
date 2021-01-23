    <Style x:Key="FadeInOut" TargetType="Grid">
       <Style.Triggers>
           <DataTrigger Binding="{Binding IsMouseOver, ElementName=grdMain}" 
                                  Value="true">
               <DataTrigger.EnterActions>
                 <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Duration="0:0:1" To="40" 
                         Storyboard.TargetProperty="Height"/>
                    </Storyboard>
                </BeginStoryboard>
               </DataTrigger.EnterActions>
               <DataTrigger.ExitActions>
                   <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation Duration="0:0:1" To="0" 
                          Storyboard.TargetProperty="Height"/>
                    </Storyboard>
                </BeginStoryboard>
               </DataTrigger.ExitActions>
           </DataTrigger>
       </Style.Triggers>
    </Style>
