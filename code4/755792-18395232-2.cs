           @{
               int groupings = 3;
               var grouped = Model.Select((x,i) => new { x, i = i / groupings  })
                             .GroupBy(x => x.i, x => x.x);
           }
           <table id="memberlist">
           <tbody>
            @foreach(var items in grouped)
             {
              <tr>
                 @foreach(var item in items)
                 {
                     <td>Rtn. @item.Mem_NA<br />(@item.Mem_Occ)</td>
                 }
              </tr>
             }
           </tbody>
           </table>
