    var entities = new DababaseEntities();
    
    List<FabricLineView> fabricLines =  entities .Line.Select(x=> new FabricLineView { ID = x.LineaID, Name = x.LineaNombre }).ToList();
    
    DropDownListFabricLines.DataValueField = "ID";
    DropDownListFabricLines.DataTextField = "Name";
    DropDownListFabricLines.DataSource = fabricLines;
    DropDownListFabricLines.DataBind();
    
    
    public sealed class FabricLineView
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
