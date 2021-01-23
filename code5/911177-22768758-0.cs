    public class WolfPack {
       
       // composed of items
       private List<Wolf> _wolves = new List<Wolf>();
       // lets you add items
       public void Add( Wolf wolf ) {
          this._wolves.Add( wolf );
       }
       public IEnumerable<Wolf>() {
          return this._wolves;
       }
       public Wolf Omega { get; set; }
    ...
