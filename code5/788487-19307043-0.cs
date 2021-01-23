    public List<DummyModel> Method(int id)
        {
            return _context.Visitas.Where(a => a.CicloId == id).GroupBy(a => a.Estado).
                Select(n => new DummyModel { Name = n.Key.Descripcion, Value = n.Count() }).ToList();
        }
