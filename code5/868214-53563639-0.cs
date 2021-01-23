    public async Task<Unit> Handle(UpdateCustomCommand<TType> request, CancellationToken cancellationToken)
        {
            //TODO: set access based on user credentials
            var contextCollectionProp = _context.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .FirstOrDefault(e => e.PropertyType == typeof(DbSet<TType>));
            if (contextCollectionProp == null)
            {
                throw new UnSupportedCustomEntityTypeException(typeof(TType), "DB Contexts doesn't contains collection for this type.");
            }
            var firstOrDefaultMethod = typeof(System.Linq.Queryable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                .FirstOrDefault(m => m.Name == "FirstOrDefault" && m.GetParameters().Count() == 2);
            if (firstOrDefaultMethod == null)
            {
                throw new UnSupportedCustomEntityTypeException(typeof(TType), "Cannot find \"Syste.Linq.FirstOrDefault\" method.");
            }
            Expression<Func<TType, bool>> expr = e => request.Id.Equals(e.ID);
            firstOrDefaultMethod = firstOrDefaultMethod.MakeGenericMethod(typeof(TType));
            TType item = firstOrDefaultMethod.Invoke(null, new[] { contextCollectionProp.GetValue(_context), expr }) as TType;
            if (item == null)
            {
                throw new NotFoundException(nameof(TType), request.Id);
            }
            //TODO: use any mapper instead of following code
            item.Code = request.Code;
            item.Description = request.Description;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
