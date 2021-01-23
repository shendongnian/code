    PS C:\> @'
    >>> <Configuration>
    >>>   <ViewDefinitions>
    >>>     <View>
    >>>       <Name>SomeObject</Name>
    >>>       <ViewSelectedBy>
    >>>          <TypeName>SomeObject</TypeName>
    >>>       </ViewSelectedBy>
    >>>       <TableControl>
    >>>         <TableHeaders>
    >>>           <TableColumnHeader>
    >>>             <Label>SomeObject</Label>
    >>>           </TableColumnHeader>
    >>>         </TableHeaders>
    >>>         <TableRowEntries>
    >>>           <TableRowEntry>
    >>>             <TableColumnItems>
    >>>               <TableColumnItem>
    >>>                 <ScriptBlock>$_.ToString()</ScriptBlock>
    >>>               </TableColumnItem>
    >>>             </TableColumnItems>
    >>>           </TableRowEntry>
    >>>          </TableRowEntries>
    >>>       </TableControl>
    >>>     </View>
    >>>   </ViewDefinitions>
    >>> </Configuration>
    >>> '@ > SomeObject.format.ps1xml
    
    PS C:\> Update-FormatData .\SomeObject.format.ps1xml
    PS C:\> $o
    SomeObject
    ----------
    Hello
