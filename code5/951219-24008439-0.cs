    <TreeView Name="MyTreeview" .........>
     <TreeView.ContextMenu x:Uid="cxt">                            
          <ContextMenu Name="ContextMenu">                                          
           <MenuItem Name="AddNew" Header="Add" Click="AddNew_Click"></MenuItem>
          <Separator/>
          <MenuItem Name="CopyItem" Header="Copy(Ctrl + C)"  Click="CopyItemy_Click"> </MenuItem>
                                   
           </ContextMenu>
     </TreeView.ContextMenu>
     ......
    </TreeView>
