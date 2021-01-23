    public virtual object NullSafeGet(IDataReader rs, string name)
		{
            int index = 0;
            try
            {
                name = name.ToUpperInvariant();
                index = rs.GetOrdinal(name);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0} Not Found", name));
            }
...
}
