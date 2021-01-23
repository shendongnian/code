            var list = new List<AppSettings>();
            var item = list.FirstOrDefault(x => x.Name == NameEnteredByUser);
            if (item == null)
            {
                //there is no such item
            }
            else
            {
               //notify the user
            }
        
