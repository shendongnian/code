    public class MyViewModel
    {
       public MyModelView(CompositePiece cp)
       {
          CompositePiece = cp;
          Components = cp.Components.ToList();
       }
       public CompositePiece CompositePiece { get; set; }
       public List<Component> Components { get; set; }
    }
