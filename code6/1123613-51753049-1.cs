    protected List<object> ExecuteMultiQuery<A, B, C, D, E, F, G, H, I, J>(string procedureName, DynamicParameters param = null)
        {
            List<object> result = new List<object>();
            using (var connection = new SqlConnection(ConnectionManager.ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (var multi = connection.QueryMultiple(procedureName, param, commandType: CommandType.StoredProcedure, commandTimeout: 120))
                    {
                        var varA = multi.Read<A>();
                        if (varA != null) { result.Add(varA.ToList()); }
                        var varB = multi.Read<B>();
                        if (varB != null) { result.Add(varB.ToList()); }
                        var varC = multi.Read<C>();
                        if (varC != null) { result.Add(varC.ToList()); }
                        var varD = multi.Read<D>();
                        if (varD != null) { result.Add(varD.ToList()); }
                        var varE = multi.Read<E>();
                        if (varE != null) { result.Add(varE.ToList()); }
                        var varF = multi.Read<F>();
                        if (varF != null) { result.Add(varF.ToList()); }
                        var varG = multi.Read<G>();
                        if (varG != null) { result.Add(varG.ToList()); }
                        var varH = multi.Read<H>();
                        if (varH != null) { result.Add(varH.ToList()); }
                        var varI = multi.Read<I>();
                        if (varI != null) { result.Add(varI.ToList()); }
                        var varJ = multi.Read<J>();
                        if (varJ != null) { result.Add(varJ.ToList()); }
                        //if (varA != null) { result.Add(varA.ToList()); }
                        //if (resultSets > 1) { result.Add(multi.Read<B>().ToList()); }
                        //if (resultSets > 2) { result.Add(multi.Read<C>().ToList()); }
                        //if (resultSets > 3) { result.Add(multi.Read<D>().ToList()); }
                        //if (resultSets > 4) { result.Add(multi.Read<E>().ToList()); }
                        //if (resultSets > 5) { result.Add(multi.Read<F>().ToList()); }
                        //if (resultSets > 6) { result.Add(multi.Read<G>().ToList()); }
                        //if (resultSets > 7) { result.Add(multi.Read<H>().ToList()); }
                        //if (resultSets > 8) { result.Add(multi.Read<I>().ToList()); }
                        //if (resultSets > 9) { result.Add(multi.Read<J>().ToList()); }    
                        return result;
                    }
                }
                catch (System.Exception e)
                {
                    string message = e.Message;
                }
            }
            return result;
        }
