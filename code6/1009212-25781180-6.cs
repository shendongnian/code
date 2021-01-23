    public List<Departement> GetDepartements(int? directionId)
            {
                List<Departement> res = new List<Departement>();
                using (SerializerContext context = new SerializerContext())
                {
                    if(id.HasValue)
                    {
                        res = context.DepartementSet.Where(d => d.IdDirection == directionId).ToList();
                    }
                    else
                    {
                        res = context.DirectionSet.ToList();
                    }
                }
                return res;
            }
     
