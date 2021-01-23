    using System.Web.UI.WebControls;
    List<Literal> literals = new List<Literal>();
    foreach (Literal literal in this.Controls.OfType<Literal>()) 
    {
        literals.Add(literal);
    }
