    private void TransfertToOriginal(simulation item)
        {
            List<string> ll = new List<string>();
            
            try 
            {
            //Echeances that will be marked as deleted => found in "echeancier" 
            //and not in echeancierCopy
            
    var EcheancesForDelete = item.echeancier.Except(item.echeancierCopy, new  EcheanceNumberComparer());
            
    //Echeances that will be marked as modified => found in 2 collections
            var EcheancesForModify      = item.echeancier.Intersect(item.echeancierCopy,   new EcheanceNumberComparer());
    //Echeances that will be marked as Added => found in "echeancierCopy" and not in "echeancier"
            var EcheancesForAdd         = item.echeancierCopy.Except(item.echeancier, new EcheanceNumberComparer());
           
    //Beware to cast EcheancesForDelete collection To List otherwise an exception Collection was modified
    foreach (Echeance ee in EcheancesForDelete.ToList())
            {
                base.GetCurrentUoW().Attach<Echeance>(ee);
                base.GetCurrentUoW().RegisterDeleted<Echeance>(ee);
            }
    //Modification ....Don't forget ToList()
       foreach (Echeance ee in EcheancesForModify.ToList())
            {
                base.GetCurrentUoW().Attach<Echeance>(ee);
                base.GetCurrentUoW().RegisterChanged<Echeance>(ee);
            }
    //New records here
            foreach (Echeance ee in EcheancesForAdd.ToList())
            {
                base.GetCurrentUoW().Attach<Echeance>(ee);
                base.GetCurrentUoW().RegisterNew<Echeance>(ee);
            }
           
               
            
            }
            catch (Exception ex)
            {
            
                _logger.LogException(ex);
                throw ex;
            }
            
        }
