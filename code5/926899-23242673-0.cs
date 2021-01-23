        [SqlMethod(IsDeterministic=true, IsPrecise=false)]
        public SqlGeometry STUnion(SqlGeometry other)
        {
            if (this.IsNull || other == null || other.IsNull || this.Srid != other.Srid)
            {
                return SqlGeometry.Null;
            }
            this.ThrowIfInvalid();
            other.ThrowIfInvalid();
            return SqlGeometry.Construct(GLNativeMethods.Union(this.GeoData, other.GeoData), this.Srid);
        }
