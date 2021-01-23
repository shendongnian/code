    public class Soldiers
    {
      private string[] _soldiers;
      private Dictionary<int, Decoration> _decorations = new Dictionary<int, Decoration>();
      public Soldiers(string[] soldier)
      {
        this._soldiers = soldier;
      }
      public Decoration this[int index]
      {
        get
        {
          Decoration decoration = new Decoration();
          this._decorations.Add(index, decoration);
          return this._decorations[index];
        }
      }
      public override string ToString()
      {
        var soldierList = new List<string>();
        for (var i = 0; i < this._soldiers.Length; i++)
        {
          string soldier = this._soldiers[i];
          if (this._decorations.ContainsKey(i))
            soldier = soldier + ", Decoration: " + this._decorations.ElementAt(i).ToString();
          soldierList.Add(soldier);
        }
        return string.Join("; ", soldierList);
      }
      public class Decoration
      {
        public bool Bronze;
        public bool Silver;
        public bool Gold;
      	public override string ToString()
	    {
	      return (this.Bronze ? "Bronze," : "") + (this.Silver ? "Silver," : "") + (this.Gold ? "Gold" : "")
	    }
      }
    }
