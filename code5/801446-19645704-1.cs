    public IQueryable<JoinedDataModel> GetJoinedView( )
    {
        return from a in DbContext.Set<TableA>()
               join b on DbContext.Set<TableB>() a.ID equals b.TableAID
               join c on DbContext.Set<TableC>() b.ID equals c.TableBID
               select new JoinedDataModel( )
               {
                    DataA = a,
                    DataB = b,
                    DataC = c
               };
    }
