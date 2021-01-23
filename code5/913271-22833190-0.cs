    public IHttpActionResult GetГрафик(int id)
            {
                xTourist t = db.xTourist.Find(id);
                var beach = db.xAdres.Find(t.Hotel).Kod;
                var result = from a in db.Grafik
                              join b in db.Excursions on a.Excursion equals b.Kod
                              join c in db.Dates on a.Kodd equals c.Kodd      
                              join d in db.Staff on a.Guidename equals d.Kod
                              join e in db.Заказы on a.КодГ equals e.КодГ
                             where c.Дата > t.Датапр && c.Дата < t.Датаотл
                              let pu = from x in db.xPickUp where x.КодП == beach && x.Excursion == b.Kod select x.PickUpTime
                                       orderby c.Дата
                                       let pl = a.Пребукинг - (e.Child + e.Pax)
                              select new { kodg = a.КодГ, excursion = b.Название, guide = d.Name, data = c.Дата, pricead = b.Price, 
                                  pricech = b.PriceChd, pax = t.Колчел, child = t.Дети, paxleft = pl, pickup = pu.FirstOrDefault()};
                return Ok(result);
            }
