     var response = VodCatalogBUS.GetParentThematics(); 
            List<oboThematic> list = new List<oboThematic>();
            
            list = response.Data;
                       
                list.RemoveAll(x => x.IsAdult == true && x.Id != 1007);
                var responseAdult = VodCatalogBUS.GetParentThematics(); 
                List<oboThematic> listAdult = new List<oboThematic>();
                listAdult = responseAdult.Data;
                listAdult.RemoveAll(y => y.IsAdult == false && y.Id != 1007);                
            
            ViewBag.DDL = new SelectList(list, "Id", "Name");
            ViewBag.DDLAdult = new SelectList(listAdult, "Id", "Name");
