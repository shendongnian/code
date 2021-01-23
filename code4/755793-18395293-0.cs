    <table id="memberlist">
    <tbody>
        @foreach(var item in Model)
        {
            if( total % 4 == 0 ){
            @:<tr>
            }
            <td>Rtn. @item.Mem_NA<br />(@item.Mem_Occ)</td>
            if( total+1 % 5 == 0 ){
            @:</tr>
            }
            total++;
        }
    </tbody>
