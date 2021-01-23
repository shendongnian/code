    <Button Content="SomeButton">
        <Interactivity:Interaction.Triggers>
          <Interactivity:EventTrigger EventName="MouseOver">
             <Interactivity:InvokeCommandAction Command="{Binding SomeButtonMouseOverCommand}" />
          </Interactivity:EventTrigger>
       </Interactivity:Interaction.Triggers>
    </Button>
    
