    var intMap = new Dictionary<int?, Func<Environment, int>> 
    {
        { id, item => item.IdCiaDespliegue },
        { id2, item => item.IdContenidoEntorno },
        { entorno, item => item.DebeEtiquetar }
    }
    
    var list = Model.Environments;
    
    foreach(var pair in intMap)
    {
        if(pair.Key != null)
            list = list.Where(item => pair.Value(item).Equals(pair.Key.Value));
    }
