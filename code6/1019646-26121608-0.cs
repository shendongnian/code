    var items = from v in work.GetRepo<VW_V>().Query
            join k in work.GetRepo<K>().Query on v.Loc_Id equals k.Id
            join p in work.GetRepo<P>().Query on v.Peer_Id equals p.Id into subpeer_j
            from subpeer in subpeer_j.DefaultIfEmpty()
            join tt in work.GetRepo<TT>().Query on v.Item_Id equals tt.Id
            select (new MyModel
            {
                Id = v.Id,
                Location = k != null ? k.Name : string.Empty,
                ItemName = tt.Name,
                Peer = subpeer != null ? subpeer.Name : string.Empty,
            });
