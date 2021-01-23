            public void UpdateBulk(IEnumerable<Position> pDokumentPosition, DbDal pCtx)
            {
                    foreach (Position vPos in pDokumentPosition)
                    {
                        vPos.LastDateChanged = DateTime.Now;
                        pCtx.Entry(vPos).State = EntityState.Modified;
                     }
                    pCtx.SaveChanges();
            }
