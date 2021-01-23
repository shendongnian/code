    public class EmailSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request,
            ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi == null)
            {
                return new NoSpecimen(request);
            }
            if (pi.PropertyType != typeof(string)
                || pi.Name != "Email")
            {
                return new NoSpecimen(request);
            }
     
            return string.Format("{0}@fobar.com", context.Resolve(typeof(string)));
        }
    }
