        private int rankResult(TileViewModel vm, string keyword)
        {
            double rank = 0;
            
            //Added 100 to give stronger weight when keyword found in title
            int index = vm.Title.IndexOf(keyword, StringComparison.InvariantCultureIgnoreCase);
            if (index >= 0 )
            {
                rank = (double)(vm.Title.Length - index) / (double)vm.Title.Length * 100 + 100;
            }         
            
            int index2 = vm.Information.IndexOf(keyword, StringComparison.InvariantCultureIgnoreCase);
            if (index2 >= 0)
            {
                rank += (double)(vm.Information.Length - index2) / (double)vm.Information.Length * 100;
            }
 
            return Convert.ToInt32(rank);
        }
