    var query = from p in DfmSession.CurrentContext.TRN_ITMs
                join c in DfmSession.CurrentContext.CAFEs on p.Item_key equals c.Dfm_key into t
                from rt in t.DefaultIfEmpty()
                where p.Transaction_key == _dfmkey
                group p by rt.Description into g
                select new
                {
                    Description = g.Keu
                    Quantity = g.Select(x => x.Quantity).Sum()
                    Price = g.Select(x => x.Price).Sum()
                };
