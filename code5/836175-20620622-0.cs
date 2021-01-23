    public List<Prodcuts_with_sizes> SzukajProduktu(int id, string name, decimal price_from, decimal price_to)
        {
            List<Prodcuts_with_sizes> odp;
            if (id == -1) //when id is not given
            {
                using (var context = new dbMagazynierEntities())
                {
                    var q = (from p in context.Products
                                where p.Name.Contains(name) && p.Price >= price_from && p.Price <= price_to
                                join r in context.Size
                                    on p.ID equals r.Products.ID
                                    into sizes
                                select new
                                {
                                    ID = p.ID,
                                    Name = p.Name,
                                    Price = p.Price,
                                    S = sizes.Where(x => x.Name == 0).Sum(x => x.Quantity) ?? 0,
                                    M = sizes.Where(x => x.Name == 1).Sum(x => x.Quantity) ?? 0,
                                    L = sizes.Where(x => x.Name == 2).Sum(x => x.Quantity) ?? 0,
                                });
                    odp = new List<Prodcuts_with_sizes>();
                    foreach (var item in q)
                    {
                        odp.Add(new Prodcuts_with_sizes { ID = item.ID, Name = item.Name, Price = item.Price, S = item.S, M = item.M, L = item.L });
                    }
                    //dataGridView1.DataSource = q.ToList();
                }
                return odp;
            }
            else //when id is given
            {
                using (var context = new dbMagazynierEntities())
                {
                    var q = (from p in context.Products
                                where p.ID == id
                                join r in context.Sizes
                                    on p.ID equals r.Products.ID
                                    into sizes
                                select new
                                {
                                    ID = p.ID,
                                    Name = p.Name,
                                    Price = p.Price,
                                    S = sizes.Where(x => x.Name == 0).Sum(x => x.Quantity) ?? 0,
                                    M = sizes.Where(x => x.Name == 1).Sum(x => x.Quantity) ?? 0,
                                    L = sizes.Where(x => x.Name == 2).Sum(x => x.Quantity) ?? 0,
                                });
                    odp = new List<Prodcuts_with_sizes>();
                    foreach (var item in q)
                    {
                        odp.Add(new Prodcuts_with_sizes { ID = item.ID, Name = item.Name, Price = item.Price, S = item.S, M = item.M, L = item.L });
                    }
                }
                return odp;
            }
        }
     using (var context = new MyInterfaceClient())
                    {
                         wyn = context.SzukajProduktu(id, name.Text, price_from, price_to);
                        //return wyn;
                    }
