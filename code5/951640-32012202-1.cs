    public static Cursos GetDatosCursoById(int cursoId)
    {
        using (var bd = new AcademyEntities())
        {
            try
            {
                bd.Configuration.ProxyCreationEnabled = false;
                return bd.Cursos.FirstOrDefault(c => c.cursoId == cursoId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
