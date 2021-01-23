            if (vPos.Dokument != null)
            {
                pCtx.Entry(vPos.Dokument).State = EntityState.Detached;
            }
            if (vPos.Produkt!=null)
            {
                pCtx.Entry(vPos.Produkt).State = EntityState.Detached;
            }
            
