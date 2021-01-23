    public DTO.Firm GetById(int id) {
      using (var ctx = new MyEntities()) {
        var firm = (from f in ctx.Firms
                    where f.ID == id
                    select f).FirstOrDefault();
    
        return (DTO.Firm)firm;
      }
    }
    public List<DTO.Firm> GetAll() {
      using (var ctx = new MyEntities()) {
        return ctx.Firms.Cast<DTO.Firm>().ToList();
      }
    }
