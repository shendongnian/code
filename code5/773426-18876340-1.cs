    @foreach(var item in Model)
    {
    <h2>@item.Name</h2>
    List<Lots> listm=Model.Lots.Where(m=>m.Id==item.Id).ToList();
    foreach(var i in listm)
    {
    <h3>@i.Name</h3>
    List<Regs> listr=i.Regs.Where(m=>m.Id==i.Id).ToList();
    foreach(var j in listr)
    {
    <h4>@j.Name</h4>
 
       }
    
    }
    }
