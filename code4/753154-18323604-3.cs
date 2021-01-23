    public void listar_carros()
    {
        List<carros> Lcars = new List<carros>();
        Lcars.Add(new carros(1, "Fusca"));
        Lcars.Add(new carros(2, "Gol"));
        Lcars.Add(new carros(3, "Fiesta"));
    
        var qry = from q in Lcars
                  where q.nome.ToLower().Contains("eco")
                  orderby q.nome
                  select q;
    
        doSomething(qry);
    
    }
    
    public void doSomething(IEnumerable<carros> qry)
    {
    
        foreach (carros ca in qry)
        {
            Response.Write(ca.nome);
            Response.Write(" - ");
            Response.Write(ca.id);
            //Response.Write(ca);
            Response.Write("<br />");
        }
    }
