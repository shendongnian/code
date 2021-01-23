    public IEnumerable<Sensor> Select(TypeOfSensor typeOfSensor)
    {
        using (ISession session = NHibernateHelper.OpenSession())
        {
            return session.Query<Sensor>()
                .Where(c => c.TypeOfSensor == typeOfSensor);
        }
    }
