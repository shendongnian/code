      <StackPanel Tag="{Binding DataContext, RelativeSource={RelativeSource Self}}">
          <StackPanel.ContextMenu>
             <ContextMenu DataContext="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                   <MenuItem Header="test dosomething" cal:Message.Attach="DoSomething"/>
             </ContextMenu>
          </StackPanel.ContextMenu>
      </StackPanel> 
